SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

SET IDENTITY_INSERT Operacoes ON 

INSERT INTO Operacoes (Id,Nome,Codigo,Descricao) VALUES (1, N'Unidades Próprias', N'unidades-proprias', null)
INSERT INTO Operacoes (Id,Nome,Codigo,Descricao) VALUES (2, N'Unidade Própria (PMZL-1)', N'unidade-propria-pmzl-1', null)
INSERT INTO Operacoes (Id,Nome,Codigo,Descricao) VALUES (3, N'Unidades Afretadas', N'unidades-afretadas', null)

SET IDENTITY_INSERT Operacoes OFF
SET IDENTITY_INSERT NivelOperacoes ON 

INSERT NivelOperacoes (Id, NivelId, OperacaoId) VALUES (1, 1, 1)
INSERT NivelOperacoes (Id, NivelId, OperacaoId) VALUES (2, 3, 1)
INSERT NivelOperacoes (Id, NivelId, OperacaoId) VALUES (3, 4, 1)
INSERT NivelOperacoes (Id, NivelId, OperacaoId) VALUES (4, 5, 1)
INSERT NivelOperacoes (Id, NivelId, OperacaoId) VALUES (5, 1, 2)
INSERT NivelOperacoes (Id, NivelId, OperacaoId) VALUES (6, 2, 2)
INSERT NivelOperacoes (Id, NivelId, OperacaoId) VALUES (7, 4, 2)
INSERT NivelOperacoes (Id, NivelId, OperacaoId) VALUES (8, 6, 3)
INSERT NivelOperacoes (Id, NivelId, OperacaoId) VALUES (9, 7, 3)
INSERT NivelOperacoes (Id, NivelId, OperacaoId) VALUES (10, 8, 3)

SET IDENTITY_INSERT NivelOperacoes OFF

UPDATE Ueps
SET OperacaoId = 1
WHERE EXISTS (SELECT 1
			  FROM NivelUeps
			  WHERE NivelUeps.UepId = Ueps.Id
			  AND NivelUeps.Id <= 28)

UPDATE Ueps
SET OperacaoId = 2
WHERE EXISTS (SELECT 1
			  FROM NivelUeps
			  WHERE NivelUeps.UepId = Ueps.Id
			  AND NivelUeps.Id >= 29
			  AND NivelUeps.Id <= 31)

UPDATE Ueps
SET OperacaoId = 3
WHERE EXISTS (SELECT 1
			  FROM NivelUeps
			  WHERE NivelUeps.UepId = Ueps.Id
			  AND NivelUeps.Id >= 32)

UPDATE Agentes
SET Nome = (SELECT Nome FROM Ambientais WHERE Ambientais.AgenteId = Agentes.Id),
	Codigo = (SELECT Codigo FROM Ambientais WHERE Ambientais.AgenteId = Agentes.Id),
	Descricao = (SELECT Descricao FROM Ambientais WHERE Ambientais.AgenteId = Agentes.Id)
WHERE OrigemId = 1

UPDATE Agentes
SET Nome = (SELECT Nome FROM Equipamentos WHERE Equipamentos.AgenteId = Agentes.Id),
	Codigo = (SELECT Codigo FROM Equipamentos WHERE Equipamentos.AgenteId = Agentes.Id),
	Descricao = (SELECT Descricao FROM Equipamentos WHERE Equipamentos.AgenteId = Agentes.Id)
WHERE OrigemId = 2

UPDATE Agentes
SET Nome = (SELECT Nome FROM Humanas WHERE Humanas.AgenteId = Agentes.Id),
	Codigo = (SELECT Codigo FROM Humanas WHERE Humanas.AgenteId = Agentes.Id),
	Descricao = (SELECT Descricao FROM Humanas WHERE Humanas.AgenteId = Agentes.Id)
WHERE OrigemId = 3

UPDATE Agentes
SET Nome = N'Não identificado',
	Codigo = N'nao identificado',
	Descricao = NULL
WHERE OrigemId = 4

SET IDENTITY_INSERT OrigemAgentes ON 

INSERT OrigemAgentes (Id, OrigemId, AgenteId)
(SELECT Id, OrigemId, Id
   FROM Agentes)

SET IDENTITY_INSERT OrigemAgentes OFF

INSERT EventoIniciadores (EventoId, IniciadorId)
SELECT Eventos.Id, Iniciadores.Id
   FROM Eventos, Iniciadores
 ORDER BY Eventos.Id, Iniciadores.Id
GO

UPDATE Esds
SET NivelOperacaoId = (SELECT nop.Id FROM NivelUeps nu JOIN Ueps u ON u.Id = nu.UepId JOIN NivelOperacoes nop ON u.OperacaoId = nop.OperacaoId AND nu.NivelId = nop.NivelId WHERE nu.Id = Esds.NivelUepId),
    EventoIniciadorId = (SELECT ei.Id FROM EquipamentoIniciadorUeps eiu JOIN IniciadorUeps iu ON iu.Id = eiu.IniciadorUepId JOIN EventoIniciadores ei ON ei.EventoId = iu.IniciadorId AND ei.IniciadorId = eiu.EquipamentoId WHERE eiu.Id = Esds.EquipamentoIniciadorUepId),
	OrigemAgenteId = (SELECT oa.Id FROM Agentes a JOIN Origens o ON o.Id = a.OrigemId JOIN OrigemAgentes oa ON oa.OrigemId = o.Id AND oa.AgenteId = a.Id WHERE a.Id = Esds.AgenteId)
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER VIEW vwEsd as
SELECT Esd.Id
      ,Esd.DataEvento
	  ,Unidade.Id as UnidadeId
	  ,Unidade.Codigo as UnidadeCodigo
	  ,Unidade.Nome as UnidadeNome
	  ,Ativo.Id as AtivoId
	  ,Ativo.Codigo as AtivoCodigo
	  ,Ativo.Nome as AtivoNome
	  ,Esd.UepId
	  ,Uep.Codigo as UepCodigo
	  ,Uep.Nome as UepNome
      ,Esd.NivelOperacaoId as NivelOperacaoId
	  ,NivelOperacao.NivelId
	  ,Nivel.Nome as NivelNome
	  ,Nivel.Codigo as NivelCodigo
	  ,Esd.EventoIniciadorId
      ,EventoIniciador.EventoId
	  ,Evento.Nome as EventoNome
	  ,Evento.Codigo as EventoCodigo
	  ,EventoIniciador.IniciadorId
	  ,Iniciador.Nome as IniciadorNome
	  ,Iniciador.Codigo as IniciadorCodigo
	  ,Esd.MotivoCausaId
      ,MotivoCausa.MotivoId
	  ,Motivo.Nome as MotivoNome
	  ,Motivo.Codigo as MotivoCodigo
      ,MotivoCausa.CausaId
	  ,Causa.Nome as CausaNome	  
	  ,Causa.Codigo as CausaCodigo
	  ,Esd.OrigemAgenteId
	  ,OrigemAgente.OrigemId
	  ,Origem.Nome as OrigemNome
	  ,Origem.Codigo as OrigemCodigo
      ,OrigemAgente.AgenteId
	  ,Agente.Nome as AgenteNome
	  ,Agente.Codigo as AgenteCodigo
      ,Esd.Descricao
	  ,Ativo.Codigo + ' ' + Uep.Codigo + ' ' + Nivel.Codigo + ' ' + Iniciador.Codigo + ' ' 
	  + Evento.Codigo + ' ' + Motivo.Codigo + ' ' + Causa.Codigo + ' ' + Origem.Codigo + ' ' 
	  + Agente.Codigo + ' ' + dbo.RemoveDiacritics(Esd.Descricao) as DescricaoCodigo
  FROM Esds as Esd
  INNER JOIN Ueps as Uep ON Uep.Id = Esd.UepId
  INNER JOIN Ativos as Ativo ON Ativo.Id = Uep.AtivoId
  INNER JOIN UnidadesOperativas as Unidade ON Unidade.Id = Ativo.UnidadeOperativaId
  INNER JOIN NivelOperacoes as NivelOperacao ON NivelOperacao.Id = Esd.NivelOperacaoId
  INNER JOIN Niveis as Nivel ON Nivel.Id = NivelOperacao.NivelId
  INNER JOIN EventoIniciadores as EventoIniciador ON EventoIniciador.Id = Esd.EventoIniciadorId
  INNER JOIN Eventos as Evento ON Evento.Id = EventoIniciador.EventoId
  INNER JOIN Iniciadores as Iniciador ON Iniciador.Id = EventoIniciador.IniciadorId
  INNER JOIN MotivoCausas as MotivoCausa ON MotivoCausa.Id = Esd.MotivoCausaId
  INNER JOIN Motivos as Motivo ON Motivo.Id = MotivoCausa.MotivoId
  INNER JOIN Causas as Causa ON Causa.Id = MotivoCausa.CausaId
  INNER JOIN OrigemAgentes as OrigemAgente ON OrigemAgente.Id = Esd.OrigemAgenteId
  INNER JOIN Origens as Origem ON Origem.Id = OrigemAgente.OrigemId
  INNER JOIN Agentes as Agente ON Agente.Id = OrigemAgente.AgenteId
GO

DROP VIEW vwNivelUep
GO

DROP VIEW vwEquipamentoIniciadorUep
GO

DROP VIEW vwIniciadorUep
GO

DROP VIEW vwAgenteOrigem
GO

DROP VIEW vwAgenteEspecifico
GO

DROP VIEW vwAgenteGenerico
GO