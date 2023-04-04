create DATABASE dbtarefas

CREATE TABLE tarefas (
  id INT AUTO_INCREMENT PRIMARY KEY,
  descricao VARCHAR(255),
  status VARCHAR(255),
  data DATE
);
