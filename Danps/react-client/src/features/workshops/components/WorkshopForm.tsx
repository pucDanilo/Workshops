import { useState, type FormEvent } from "react";
import type { WorkshopResponse } from "../types";

interface WorkshopFormProps {
    initialValues?: Partial<WorkshopResponse>;
    onSubmit: (data: Partial<WorkshopResponse>) => Promise<void>;
    submitLabel?: string;
}

export default function WorkshopForm({
    initialValues,
    onSubmit,
    submitLabel = "Salvar",
}: WorkshopFormProps) {
    const [formData, setFormData] = useState<Partial<WorkshopResponse>>({
        title: "",
        description: "",
        startAt: "",
        endAt: "",
        location: "",
        capacity: 0,
        isOnline: false,
        ...initialValues,
    });

    const [loading, setLoading] = useState(false);

    const handleSubmit = async (e: FormEvent) => {
        e.preventDefault();
        setLoading(true);
        try {
            await onSubmit(formData);
        } finally {
            setLoading(false);
        }
    };

    return (
        <form onSubmit={handleSubmit} className="flex-col" style={{ gap: '12px' }}>
            <div className="form-group">
                <label>Título</label>
                <input
                    required
                    placeholder="Ex: Workshop de React"
                    value={formData.title}
                    onChange={(e) => setFormData({ ...formData, title: e.target.value })}
                    className="input-field"
                />
            </div>

            <div className="form-group">
                <label>Descrição</label>
                <textarea
                    required
                    rows={3}
                    placeholder="Detalhes do evento..."
                    value={formData.description}
                    onChange={(e) => setFormData({ ...formData, description: e.target.value })}
                    className="input-field"
                    style={{ resize: 'vertical' }}
                />
            </div>

            <div style={{ display: 'flex', gap: '8px' }}>
                <div style={{ flex: 1 }}>
                    <label>Início</label>
                    <input
                        required
                        type="datetime-local"
                        value={formData.startAt}
                        onChange={(e) => setFormData({ ...formData, startAt: e.target.value })}
                        className="input-field"
                    />
                </div>
                <div style={{ flex: 1 }}>
                    <label>Fim</label>
                    <input
                        required
                        type="datetime-local"
                        value={formData.endAt}
                        onChange={(e) => setFormData({ ...formData, endAt: e.target.value })}
                        className="input-field"
                    />
                </div>
            </div>

            <div className="form-group">
                <label>Local</label>
                <input
                    required
                    placeholder="Ex: Sala 302 ou Google Meet"
                    value={formData.location}
                    onChange={(e) => setFormData({ ...formData, location: e.target.value })}
                    className="input-field"
                />
            </div>

            <div style={{ display: 'flex', gap: '8px', alignItems: 'center' }}>
                <div style={{ flex: 1 }}>
                    <label>Capacidade Máxima</label>
                    <input
                        required
                        type="number"
                        min={1}
                        value={formData.capacity}
                        onChange={(e) => setFormData({ ...formData, capacity: Number(e.target.value) })}
                        className="input-field"
                    />
                </div>

                <label style={{ display: 'flex', alignItems: 'center', gap: '8px', cursor: 'pointer', marginTop: '24px' }}>
                    <input
                        type="checkbox"
                        checked={formData.isOnline}
                        onChange={(e) => setFormData({ ...formData, isOnline: e.target.checked })}
                        style={{ width: '20px', height: '20px' }}
                    />
                    Evento Online
                </label>
            </div>

            <button
                type="submit"
                disabled={loading}
                className="btn btn-primary"
                style={{ marginTop: '16px' }}
            >
                {loading ? "Salvando..." : submitLabel}
            </button>
        </form>
    );
}
