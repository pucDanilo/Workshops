import { useEffect, useState } from "react";
import { useAuth } from "../context/AuthContext";
import {
  searchWorkshops,
  createWorkshop,
  updateWorkshop,
  deleteWorkshop,
} from "../api/workshopService";
import type { WorkshopResponse } from "../api/models";

export default function WorkshopsPage() {
  const { token } = useAuth();

  // Estado da lista
  const [workshops, setWorkshops] = useState<WorkshopResponse[]>([]);
  const [total, setTotal] = useState(0);
  const [page, setPage] = useState(1);
  const [pageSize] = useState(5);

  // Estado de busca
  const [query, setQuery] = useState("");

  // Estado de criação
  const [newWorkshop, setNewWorkshop] = useState<Partial<WorkshopResponse>>({
    title: "",
    description: "",
    startAt: "",
    endAt: "",
    location: "",
    capacity: 0,
    isOnline: false,
  });

  // 🔄 Carregar workshops
  async function loadWorkshops() {
    if (token?.accessToken) {
      const response = await searchWorkshops(token.accessToken, page, pageSize, query);
      setWorkshops(response.data.items);
      setTotal(response.data.total);
    }
  }

  useEffect(() => {
    loadWorkshops();
  }, [page, query]);

  // ➕ Criar
  async function handleCreate() {
    if (token?.accessToken) {
      await createWorkshop(token.accessToken, newWorkshop);
      setNewWorkshop({
        title: "",
        description: "",
        startAt: "",
        endAt: "",
        location: "",
        capacity: 0,
        isOnline: false,
      });
      await loadWorkshops();
    }
  }

  // ✏️ Editar (exemplo: atualiza título)
  async function handleUpdate(id: string) {
    if (token?.accessToken) {
      await updateWorkshop(token.accessToken, id, { title: "Título atualizado" });
      await loadWorkshops();
    }
  }

  // ❌ Excluir
  async function handleDelete(id: string) {
    if (token?.accessToken) {
      await deleteWorkshop(token.accessToken, id);
      await loadWorkshops();
    }
  }

  return (
    <div>
      <h2>Workshops</h2>

      {/* 🔎 Busca */}
      <div>
        <input
          placeholder="Buscar..."
          value={query}
          onChange={(e) => setQuery(e.target.value)}
        />
        <button onClick={() => setPage(1)}>Buscar</button>
      </div>

      {/* ➕ Criar novo */}
      <h3>Criar novo workshop</h3>
      <input
        placeholder="Título"
        value={newWorkshop.title}
        onChange={(e) => setNewWorkshop({ ...newWorkshop, title: e.target.value })}
      />
      <input
        placeholder="Descrição"
        value={newWorkshop.description}
        onChange={(e) => setNewWorkshop({ ...newWorkshop, description: e.target.value })}
      />
      <input
        type="datetime-local"
        value={newWorkshop.startAt}
        onChange={(e) => setNewWorkshop({ ...newWorkshop, startAt: e.target.value })}
      />
      <input
        type="datetime-local"
        value={newWorkshop.endAt}
        onChange={(e) => setNewWorkshop({ ...newWorkshop, endAt: e.target.value })}
      />
      <input
        placeholder="Local"
        value={newWorkshop.location}
        onChange={(e) => setNewWorkshop({ ...newWorkshop, location: e.target.value })}
      />
      <input
        type="number"
        placeholder="Capacidade"
        value={newWorkshop.capacity}
        onChange={(e) => setNewWorkshop({ ...newWorkshop, capacity: Number(e.target.value) })}
      />
      <label>
        Online?
        <input
          type="checkbox"
          checked={newWorkshop.isOnline}
          onChange={(e) => setNewWorkshop({ ...newWorkshop, isOnline: e.target.checked })}
        />
      </label>
      <button onClick={handleCreate}>Criar</button>

      {/* 📋 Lista */}
      <h3>Lista de workshops</h3>
      <ul>
        {workshops.map((w) => (
          <li key={w.id}>
            <strong>{w.title}</strong> — {w.location}
            <br />
            {new Date(w.startAt).toLocaleString()} até {new Date(w.endAt).toLocaleString()}
            <br />
            <button onClick={() => handleUpdate(w.id)}>Editar</button>
            <button onClick={() => handleDelete(w.id)}>Excluir</button>
          </li>
        ))}
      </ul>

      {/* 📄 Paginação */}
      <div>
        Página {page} de {Math.ceil(total / pageSize)}
        <br />
        <button disabled={page <= 1} onClick={() => setPage(page - 1)}>
          Anterior
        </button>
        <button disabled={page >= Math.ceil(total / pageSize)} onClick={() => setPage(page + 1)}>
          Próxima
        </button>
      </div>
    </div>
  );
}
