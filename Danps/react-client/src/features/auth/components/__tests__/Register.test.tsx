import { render, screen, fireEvent, waitFor } from '@testing-library/react';
import { describe, it, expect, vi, beforeEach } from 'vitest';
import { BrowserRouter } from 'react-router-dom';
import Register from '../Register';
import * as authService from '../../api/authService';
import * as AuthContext from '../../context/AuthContext';

// Mock dependencies
vi.mock('../../api/authService');
vi.mock('react-router-dom', async () => {
    const actual = await vi.importActual<any>('react-router-dom');
    return {
        ...actual,
        useNavigate: () => vi.fn(),
    };
});

const mockSetToken = vi.fn();
const mockUseAuth = {
    setToken: mockSetToken,
    token: null,
    isAuthenticated: false,
    logout: vi.fn(),
    hasRole: vi.fn().mockReturnValue(false),
};

describe('Register Component', () => {
    beforeEach(() => {
        vi.clearAllMocks();
        vi.spyOn(AuthContext, 'useAuth').mockImplementation(() => mockUseAuth);
    });

    it('renders register form correctly', () => {
        render(
            <BrowserRouter>
                <Register />
            </BrowserRouter>
        );

        expect(screen.getByPlaceholderText('Nome')).toBeInTheDocument();
        expect(screen.getByPlaceholderText('CPF')).toBeInTheDocument();
        expect(screen.getByPlaceholderText('E-mail')).toBeInTheDocument();
        expect(screen.getByPlaceholderText('Senha')).toBeInTheDocument();
        expect(screen.getByPlaceholderText('Confirmar Senha')).toBeInTheDocument();
    });

    it('validates password mismatch', async () => {
        render(
            <BrowserRouter>
                <Register />
            </BrowserRouter>
        );

        fireEvent.change(screen.getByPlaceholderText('Senha'), { target: { value: '123456' } });
        fireEvent.change(screen.getByPlaceholderText('Confirmar Senha'), { target: { value: '654321' } });

        fireEvent.click(screen.getByText('Criar Conta'));

        await waitFor(() => {
            expect(screen.getByText('As senhas devem coincidir')).toBeInTheDocument();
        });
    });

    it('calls register service on success', async () => {
        const mockRegisterResponse = {
            data: {
                accessToken: 'fake-token',
                // ... other fields
            }
        };

        (authService.register as any).mockResolvedValue(mockRegisterResponse);

        render(
            <BrowserRouter>
                <Register />
            </BrowserRouter>
        );

        // Fill all required fields
        fireEvent.change(screen.getByPlaceholderText('Nome'), { target: { value: 'User Test' } });
        fireEvent.change(screen.getByPlaceholderText('CPF'), { target: { value: '12345678901' } }); // Assuming simple string for now
        fireEvent.change(screen.getByPlaceholderText('E-mail'), { target: { value: 'newuser@example.com' } });
        fireEvent.change(screen.getByPlaceholderText('Senha'), { target: { value: 'password123' } });
        fireEvent.change(screen.getByPlaceholderText('Confirmar Senha'), { target: { value: 'password123' } });

        fireEvent.click(screen.getByText('Criar Conta'));

        await waitFor(() => {
            expect(authService.register).toHaveBeenCalled();
            expect(mockSetToken).toHaveBeenCalledWith(mockRegisterResponse.data);
        });
    });
});
