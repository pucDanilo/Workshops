import { BrowserRouter, Routes, Route } from "react-router-dom";
import Register from "./pages/Register";
import Login from "./pages/Login";
import TokenPage from "./pages/TokenPage";
import WorkshopsPage from "./pages/WorkshopsPage";
import { PrivateRoute } from "./routes/PrivateRoute";
import Sidebar from "./components/Sidebar";
 

export default function App() {
  return (
    <BrowserRouter>
      <div style={{ display: "flex" }}>
        <Sidebar />
        <main style={{ flex: 1, padding: "20px" }}>
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
                  <WorkshopsPage />
                </PrivateRoute>
              }
            /> 
          </Routes>
        </main>
      </div>
    </BrowserRouter>
  );
}