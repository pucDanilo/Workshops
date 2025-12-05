import { render, screen, fireEvent, waitFor } from '@testing-library/react';
import { describe, it, expect, vi, beforeEach } from 'vitest';
import { BrowserRouter } from 'react-router-dom';
import Login from '../Login';
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

// Mock Auth Context
const mockSetToken = vi.fn();
const mockUseAuth = {
    setToken: mockSetToken,
    token: null,
    isAuthenticated: false,
    logout: vi.fn(),
    hasRole: vi.fn().mockReturnValue(false),
};

describe('Login Component', () => {
    beforeEach(() => {
        vi.clearAllMocks();
        vi.spyOn(AuthContext, 'useAuth').mockImplementation(() => mockUseAuth);
    });

    it('renders login form correctly', () => {
        render(
            <BrowserRouter>
                <Login />
            </BrowserRouter>
        );

        expect(screen.getByPlaceholderText('E-mail')).toBeInTheDocument();
        expect(screen.getByPlaceholderText('Senha')).toBeInTheDocument();
        expect(screen.getByText('Entrar')).toBeInTheDocument();
    });

    it('validates empty fields', async () => {
        render(
            <BrowserRouter>
                <Login />
            </BrowserRouter>
        );

        fireEvent.click(screen.getByText('Entrar'));

        // Wait for validation messages
        expect(await screen.findByText('O campo Email é obrigatório')).toBeInTheDocument();
        expect(await screen.findByText('A senha deve ter no mínimo 6 caracteres')).toBeInTheDocument();
    });

    it('calls login service and redirects on success', async () => {
        const mockLoginResponse = {
            data: {
                accessToken: 'fake-token',
                refreshToken: 'fake-refresh',
                expiresIn: 3600,
                userToken: { id: '1', email: 'test@test.com', claims: [] }
            }
        };

        (authService.login as any).mockResolvedValue(mockLoginResponse);

        render(
            <BrowserRouter>
                <Login />
            </BrowserRouter>
        );

        fireEvent.change(screen.getByPlaceholderText('E-mail'), { target: { value: 'test@example.com' } });
        fireEvent.change(screen.getByPlaceholderText('Senha'), { target: { value: 'password123' } });

        fireEvent.click(screen.getByText('Entrar'));

        await waitFor(() => {
            expect(authService.login).toHaveBeenCalledWith({
                email: 'test@example.com',
                password: 'password123'
            });
            expect(mockSetToken).toHaveBeenCalledWith(mockLoginResponse.data);
        });
    });
});
