SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

SET IDENTITY_INSERT SituacaoMateriais ON 

INSERT INTO SituacaoMateriais (Id,Nome,Codigo,Descricao,Cor) VALUES (1, N'excedente', N'excedente', null,N'#008000')
INSERT INTO SituacaoMateriais (Id,Nome,Codigo,Descricao,Cor) VALUES (2, N'Alerta', N'alerta', null,N'#FFFF00')
INSERT INTO SituacaoMateriais (Id,Nome,Codigo,Descricao,Cor) VALUES (3, N'Critico', N'critico', null,N'#FF0000')

SET IDENTITY_INSERT SituacaoMateriais OFF