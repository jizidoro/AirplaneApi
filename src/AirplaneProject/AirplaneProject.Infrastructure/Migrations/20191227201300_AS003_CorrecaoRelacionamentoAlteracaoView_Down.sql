
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER VIEW [dbo].[vwAlteracao] as
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
    ,Finalidade.Codigo as FinalidadeCodigo 
    ,Finalidade.Nome as FinalidadeNome 
    ,Finalidade.Id as FinalidadeId 
    ,Camada.Codigo as CamadaCodigo 
    ,Camada.Nome as CamadaNome 
    ,Camada.Id as CamadaId 
    ,Funcao.Codigo as FuncaoCodigo 
    ,Funcao.Nome as FuncaoNome 
    ,Funcao.Id as FuncaoId 
    ,Sistema.Codigo as SistemaCodigo 
    ,Sistema.Nome as SistemaNome 
    ,Sistema.Id as SistemaId 
    ,Situacao.Codigo as SituacaoCodigo 
    ,Situacao.Nome as SituacaoNome 
    ,Situacao.Id as SituacaoId 
    ,Solicitante.Chave as SolicitanteChave 
    ,Solicitante.Nome as SolicitanteNome 
    ,Solicitante.Id as SolicitanteId 
    ,Executor.Chave as ExecutorChave 
    ,Executor.Nome as ExecutorNome 
    ,Executor.Id as ExecutorId 
    ,Aprovador.Chave as AprovadorChave 
    ,Aprovador.Nome as AprovadorNome 
    ,Aprovador.Id as AprovadorId 
    ,Autorizador.Chave as AutorizadorChave 
    ,Autorizador.Nome as AutorizadorNome 
    ,Autorizador.Id as AutorizadorId 
    ,Verificador.Chave as VerificadorChave 
    ,Verificador.Nome as VerificadorNome 
    ,Verificador.Id as VerificadorId 
    ,Evento.Descricao
    ,Ativo.Codigo + ' ' + Uep.Codigo + ' ' + Sistema.Codigo + ' ' + Situacao.Codigo + ' ' 
	  + Solicitante.Chave + ' ' + Autorizador.Chave + ' ' + Executor.Chave + ' ' + Verificador.Chave + ' ' 
	  + Aprovador.Chave + ' ' + dbo.RemoveDiacritics(Evento.Descricao) as DescricaoCodigo
  FROM Alteracoes as Evento
  INNER JOIN Ueps as Uep ON Uep.Id = Evento.UepId
  INNER JOIN Ativos as Ativo ON Ativo.Id = Uep.AtivoId
  INNER JOIN UnidadesOperativas as Unidade ON Unidade.Id = Ativo.UnidadeOperativaId
  INNER JOIN Finalidades as Finalidade ON Finalidade.Id = Evento.FinalidadeId
  INNER JOIN Camadas as Camada ON Camada.Id = Evento.CamadaId
  INNER JOIN Funcoes as Funcao ON Funcao.Id = Evento.FuncaoId
  INNER JOIN Sistemas as Sistema ON Sistema.Id = Evento.SistemaId
  INNER JOIN Situacoes as Situacao ON Situacao.Id = Evento.SituacaoId
  INNER JOIN Profissionais as Solicitante ON Solicitante.Id = Evento.SolicitanteId
  INNER JOIN Profissionais as Executor ON Executor.Id = Evento.ExecutorId
  INNER JOIN Profissionais as Aprovador ON Aprovador.Id = Evento.AprovadorId
  INNER JOIN Profissionais as Autorizador ON Autorizador.Id = Evento.AutorizadorId
  INNER JOIN Profissionais as Verificador ON Verificador.Id = Evento.VerificadorId
GO