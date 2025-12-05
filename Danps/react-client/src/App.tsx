import { BrowserRouter, Routes, Route } from "react-router-dom";
import Login from "./features/auth/components/Login";
import Register from "./features/auth/components/Register";
import TokenPage from "./features/auth/components/TokenPage";
import WorkshopListPage from "./features/workshops/components/WorkshopListPage";
import WorkshopCreatePage from "./features/workshops/components/WorkshopCreatePage";
import { PrivateRoute } from "./routes/PrivateRoute";
import { MainLayout } from "./layouts/MainLayout";

export default function App() {
  return (
    <BrowserRouter>
      <MainLayout>
        <Routes>
          <Route path="/" element={<Login />} />
          <Route path="/register" element={<Register />} />
          <Route path="/login" element={<Login />} />
          <Route
            path="/token"
            element={
              <PrivateRoute>
                <TokenPage />
              </PrivateRoute>
            }
          />
          <Route
            path="/workshops"
            element={
              <PrivateRoute>
                <WorkshopListPage />
              </PrivateRoute>
            }
          />
          <Route
            path="/workshops/new"
            element={
              <PrivateRoute>
                <WorkshopCreatePage />
              </PrivateRoute>
            }
          />
        </Routes>
      </MainLayout>
    </BrowserRouter>
  );
}