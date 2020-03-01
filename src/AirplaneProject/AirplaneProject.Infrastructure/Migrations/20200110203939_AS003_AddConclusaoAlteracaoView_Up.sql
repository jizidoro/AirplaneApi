
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwConclusaoAlteracao] as
SELECT Evento.Id
    ,Evento.DataEvento
    ,Unidade.Id as UnidadeId
	,Unidade.Codigo as UnidadeCodigo
	,Unidade.Nome as UnidadeNome
	,Ativo.Id as AtivoId
	,Ativo.Codigo as AtivoCodigo
	,Ativo.Nome as AtivoNome
    ,Uep.Id as UepId
	,Uep.Codigo as UepCodigo
	,Uep.Nome as UepNome
    ,Situacao.Codigo as SituacaoCodigo 
    ,Situacao.Nome as SituacaoNome 
    ,Situacao.Id as SituacaoId 
  FROM Alteracoes as Evento
  INNER JOIN Ueps as Uep ON Uep.Id = Evento.UepId
  INNER JOIN Ativos as Ativo ON Ativo.Id = Uep.AtivoId
  INNER JOIN UnidadesOperativas as Unidade ON Unidade.Id = Ativo.UnidadeOperativaId
  INNER JOIN Situacoes as Situacao ON Situacao.Id = Evento.SituacaoId
GO