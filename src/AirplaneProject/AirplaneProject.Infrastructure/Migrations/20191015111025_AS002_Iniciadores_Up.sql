SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

SET IDENTITY_INSERT Iniciadores ON 

DELETE FROM Iniciadores
GO

INSERT Iniciadores (Id, Nome, Codigo, Descricao)
SELECT e.Id, e.Nome, e.Codigo, e.Descricao
   FROM Equipamentos e
   WHERE e.AgenteId is null
GO

SET IDENTITY_INSERT Iniciadores OFF
GO