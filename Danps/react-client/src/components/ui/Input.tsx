import React, { forwardRef } from 'react';

interface InputProps extends React.InputHTMLAttributes<HTMLInputElement> {
    label?: string;
    error?: string;
}

export const Input = forwardRef<HTMLInputElement, InputProps>(({ label, error, className = '', ...props }, ref) => {
    return (
        <div className="input-group">
            {label && <label style={{ display: 'block', marginBottom: '4px', fontSize: '14px' }}>{label}</label>}
            <input
                ref={ref}
                className={`input-field ${className}`}
                {...props}
            />
            {error && <p style={{ color: 'var(--error-color)', fontSize: '12px', marginTop: '4px' }}>{error}</p>}
        </div>
    );
});

Input.displayName = 'Input';
