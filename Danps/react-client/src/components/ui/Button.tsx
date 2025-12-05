import React from 'react';

interface ButtonProps extends React.ButtonHTMLAttributes<HTMLButtonElement> {
    variant?: 'primary' | 'secondary' | 'text' | 'danger';
    fullWidth?: boolean;
}

export const Button: React.FC<ButtonProps> = ({
    children,
    variant = 'primary',
    fullWidth = false,
    className = '',
    style,
    ...props
}) => {
    let variantClass = 'btn';

    switch (variant) {
        case 'primary':
            variantClass = 'btn btn-primary';
            break;
        case 'text':
            variantClass = 'btn-text';
            break;
        case 'danger':
            variantClass = 'btn'; // We'll handle color via style or add a class later if needed, for now using style override pattern from existing code or adding a class
            break;
        default:
            variantClass = 'btn'; // default/secondary
    }

    // Custom styles for danger/secondary if not strictly in CSS yet, or rely on className prop
    const customStyle = { ...style };
    if (variant === 'danger') {
        customStyle.backgroundColor = '#ffebee';
        customStyle.color = '#c62828';
    } else if (variant === 'secondary') {
        customStyle.backgroundColor = '#e0e0e0';
        customStyle.color = '#000';
    }

    return (
        <button
            className={`${variantClass} ${className}`}
            style={{ width: fullWidth ? '100%' : 'auto', ...customStyle }}
            {...props}
        >
            {children}
        </button>
    );
};
