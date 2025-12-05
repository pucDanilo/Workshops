import { useNavigate } from "react-router-dom";
import { useAuth } from "../../auth/context/AuthContext";
import { createWorkshop } from "../api/workshopService";
import WorkshopForm from "./WorkshopForm";
import type { WorkshopResponse } from "../types";

export default function WorkshopCreatePage() {
    const navigate = useNavigate();
    const { token } = useAuth();

    const handleCreate = async (data: Partial<WorkshopResponse>) => {
        if (!token?.accessToken) return;

        await createWorkshop(token.accessToken, data);
        navigate("/workshops");
    };

    return (
        <div className="container">
            <div style={{ display: 'flex', alignItems: 'center', marginBottom: '24px', gap: '16px' }}>
                <button
                    onClick={() => navigate("/workshops")}
                    className="btn"
                    style={{ width: 'auto', backgroundColor: 'transparent', color: '#555', padding: '0' }}
                >
                    &larr; Voltar
                </button>
                <h2 style={{ margin: 0 }}>Criar Novo Workshop</h2>
            </div>

            <div className="card" style={{ maxWidth: '600px', margin: '0 auto' }}>
                <WorkshopForm onSubmit={handleCreate} submitLabel="Criar Workshop" />
            </div>
        </div>
    );
}
