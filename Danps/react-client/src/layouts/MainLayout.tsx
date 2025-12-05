import React from 'react';
import BottomNav from './BottomNav';

interface MainLayoutProps {
    children: React.ReactNode;
}

export const MainLayout: React.FC<MainLayoutProps> = ({ children }) => {
    return (
        <div className="flex-col full-height">
            <main className="page-content" style={{ flex: 1 }}>
                {children}
            </main>
            <BottomNav />
        </div>
    );
};
