CREATE TABLE IF NOT EXISTS Clientes (
  Id INTEGER PRIMARY KEY AUTOINCREMENT,
  Nome TEXT NOT NULL,
  Email TEXT NOT NULL,
  CriadoEm DATETIME NOT NULL
);

CREATE TABLE IF NOT EXISTS LogsLocal (
  Id INTEGER PRIMARY KEY AUTOINCREMENT,
  Message TEXT NOT NULL,
  CreatedAt DATETIME NOT NULL
);

INSERT INTO Clientes (Nome, Email, CriadoEm)
  VALUES ('Exemplo Cliente', 'exemplo@dominio.com', datetime('now'));