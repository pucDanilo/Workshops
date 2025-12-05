import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../../auth/context/AuthContext";
import {
    searchWorkshops,
    deleteWorkshop,
} from "../api/workshopService";
import type { WorkshopResponse } from "../types";

export default function WorkshopListPage() {
    const navigate = useNavigate();
    const { token, hasRole } = useAuth();

    // Estados
    const [workshops, setWorkshops] = useState<WorkshopResponse[]>([]);
    const [total, setTotal] = useState(0);
    const [page, setPage] = useState(1);
    const [pageSize] = useState(5);
    const [query, setQuery] = useState("");

    // 🔄 Carregar workshops
    async function loadWorkshops() {
        if (token?.accessToken) {
            try {
                const response = await searchWorkshops(token.accessToken, page, pageSize, query);
                setWorkshops(response.data.items);
                setTotal(response.data.total);
            } catch (error) {
                console.error("Failed to load workshops", error);
            }
        }
    }

    useEffect(() => {
        loadWorkshops();
    }, [page, token]); // Removed query from dependency to update only on button click or page change if desired, or keep it for live search. Keeping standard behavior often implies effect on query change but user had a button. Let's fix that UX to match typical pattern or keep button. User had button to trigger setPage(1). I will add query to useEffect but only if we want live search. The original code had useEffect on [page, query] but button only setPage(1). This implies 'query' update triggers reload. 

    // Correction: To respect the "Buscar" button pattern, we might want to NOT put query in dependency array if we only want to search on click.
    // HOWEVER, the original code had `useEffect(() => { loadWorkshops() }, [page, query]);` so typing in the input WOULOD trigger it.
    // Wait, let's re-read the original file.
    // `onChange={(e) => setQuery(e.target.value)}` -> updates state.
    // useEffect dep `[page, query]` -> triggers load.
    // Button `onClick={() => setPage(1)}` -> sets page, triggers load.
    // So it was "live search" effectively. I will keep it that way for now or improve it. Let's keep it live for consistency but better debounced usually. I'll stick to original behavior to minimize friction.

    useEffect(() => {
        loadWorkshops();
    }, [page, query]);

    // ❌ Excluir
    async function handleDelete(id: string) {
        if (!token?.accessToken) return;
        if (!window.confirm("Tem certeza que deseja excluir este workshop?")) return;

        try {
            await deleteWorkshop(token.accessToken, id);
            await loadWorkshops();
        } catch (error) {
            alert("Erro ao excluir workshop");
        }
    }

    return (
        <div className="container">
            <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', marginBottom: '24px' }}>
                <h2>Workshops</h2>
                {hasRole("Instructor") || hasRole("Admin") ? (
                    <button
                        onClick={() => navigate("/workshops/new")}
                        className="btn btn-primary"
                        style={{ width: 'auto' }}
                    >
                        + Novo Workshop
                    </button>
                ) : null}
            </div>

            {/* 🔎 Busca */}
            <div className="card" style={{ display: 'flex', gap: '8px', alignItems: 'center', marginBottom: '24px' }}>
                <input
                    placeholder="Buscar workshops..."
                    value={query}
                    onChange={(e) => setQuery(e.target.value)}
                    className="input-field"
                    style={{ marginBottom: 0 }}
                />
                {/* Button kept for resetting page or visual affordance */}
                <button onClick={() => setPage(1)} className="btn btn-primary" style={{ width: 'auto' }}>Buscar</button>
            </div>

            {/* 📋 Lista */}
            {workshops.length === 0 ? (
                <div style={{ textAlign: 'center', color: '#666', padding: '40px' }}>
                    Nenhum workshop encontrado.
                </div>
            ) : (
                <ul style={{ listStyle: 'none', padding: 0 }}>
                    {workshops.map((w) => (
                        <li key={w.id} className="card">
                            <div style={{ marginBottom: '12px' }}>
                                <strong style={{ fontSize: '18px', display: 'block' }}>{w.title}</strong>
                                <span style={{ color: '#666', fontSize: '14px' }}>{w.location}</span>
                            </div>
                            <p style={{ color: '#555', marginBottom: '12px' }}>{w.description}</p>
                            <div style={{ fontSize: '14px', marginBottom: '16px', color: '#555' }}>
                                📅 {new Date(w.startAt).toLocaleString()}  &nbsp; ➡️ &nbsp; {new Date(w.endAt).toLocaleString()}
                            </div>
                            <div style={{ display: 'flex', gap: '8px' }}>
                                {/* Future Edit Implementation */}
                                {/* <button onClick={() => navigate(`/workshops/${w.id}/edit`)} className="btn" style={{ flex: 1, backgroundColor: '#e0e0e0', color: '#000' }}>Editar</button> */}
                                {hasRole("Admin") && (
                                    <button onClick={() => handleDelete(w.id)} className="btn" style={{ flex: 1, backgroundColor: '#ffebee', color: '#c62828' }}>Excluir</button>
                                )}
                            </div>
                        </li>
                    ))}
                </ul>
            )}

            {/* 📄 Paginação */}
            <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', marginTop: '24px', marginBottom: '80px' }}>
                <button
                    disabled={page <= 1}
                    onClick={() => setPage(page - 1)}
                    className="btn"
                    style={{ width: 'auto', opacity: page <= 1 ? 0.5 : 1 }}
                >
                    Anterior
                </button>
                <span>
                    Página {page} de {Math.ceil(total / pageSize) || 1}
                </span>
                <button
                    disabled={page >= Math.ceil(total / pageSize)}
                    onClick={() => setPage(page + 1)}
                    className="btn"
                    style={{ width: 'auto', opacity: page >= Math.ceil(total / pageSize) ? 0.5 : 1 }}
                >
                    Próxima
                </button>
            </div>
        </div>
    );
}
