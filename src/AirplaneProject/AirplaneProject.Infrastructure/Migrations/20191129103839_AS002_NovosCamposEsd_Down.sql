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