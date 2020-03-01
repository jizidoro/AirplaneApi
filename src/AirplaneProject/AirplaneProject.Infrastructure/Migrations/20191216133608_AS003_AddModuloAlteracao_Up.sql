SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

SET IDENTITY_INSERT [dbo].[Finalidades] ON 

INSERT [dbo].[Finalidades] ([Id],[Nome],[Codigo],[Descricao]) VALUES (1,N'Melhoria',N'melhoria',NULL)
INSERT [dbo].[Finalidades] ([Id],[Nome],[Codigo],[Descricao]) VALUES (2,N'Correção',N'correcao',NULL)
INSERT [dbo].[Finalidades] ([Id],[Nome],[Codigo],[Descricao]) VALUES (3,N'Não identificado',N'nao identificado',NULL)
SET IDENTITY_INSERT [dbo].[Finalidades] OFF

SET IDENTITY_INSERT [dbo].[Camadas] ON 

INSERT [dbo].[Camadas] ([Id],[Nome],[Codigo],[Descricao]) VALUES (1,N'Controle',N'controle',NULL)
INSERT [dbo].[Camadas] ([Id],[Nome],[Codigo],[Descricao]) VALUES (2,N'Supervisão',N'supervisao',NULL)
INSERT [dbo].[Camadas] ([Id],[Nome],[Codigo],[Descricao]) VALUES (3,N'Não identificado',N'nao identificado',NULL)
SET IDENTITY_INSERT [dbo].[Camadas] OFF

SET IDENTITY_INSERT [dbo].[Funcoes] ON 

INSERT [dbo].[Funcoes] ([Id],[Nome],[Codigo],[Descricao]) VALUES (1,N'Segurança',N'seguranca',NULL)
INSERT [dbo].[Funcoes] ([Id],[Nome],[Codigo],[Descricao]) VALUES (2,N'Monitoramento',N'monitoramento',NULL)
INSERT [dbo].[Funcoes] ([Id],[Nome],[Codigo],[Descricao]) VALUES (3,N'Controle Regulatório',N'controle regulatorio',NULL)
INSERT [dbo].[Funcoes] ([Id],[Nome],[Codigo],[Descricao]) VALUES (4,N'Não identificado',N'nao identificado',NULL)
SET IDENTITY_INSERT [dbo].[Funcoes] OFF

SET IDENTITY_INSERT [dbo].[Sistemas] ON 

INSERT [dbo].[Sistemas] ([Id],[Nome],[Codigo],[Descricao]) VALUES (1,N'Sistema 1',N'sistema 1',NULL)
INSERT [dbo].[Sistemas] ([Id],[Nome],[Codigo],[Descricao]) VALUES (2,N'Sistema 2',N'sistema 2',NULL)
INSERT [dbo].[Sistemas] ([Id],[Nome],[Codigo],[Descricao]) VALUES (3,N'Sistema 3',N'sistema 3',NULL)
INSERT [dbo].[Sistemas] ([Id],[Nome],[Codigo],[Descricao]) VALUES (4,N'Sistema 4',N'sistema 4',NULL)
INSERT [dbo].[Sistemas] ([Id],[Nome],[Codigo],[Descricao]) VALUES (5,N'Sistema 5',N'sistema 5',NULL)
INSERT [dbo].[Sistemas] ([Id],[Nome],[Codigo],[Descricao]) VALUES (6,N'Sistema 6',N'sistema 6',NULL)
INSERT [dbo].[Sistemas] ([Id],[Nome],[Codigo],[Descricao]) VALUES (7,N'Sistema 7',N'sistema 7',NULL)
INSERT [dbo].[Sistemas] ([Id],[Nome],[Codigo],[Descricao]) VALUES (8,N'Sistema 8',N'sistema 8',NULL)
INSERT [dbo].[Sistemas] ([Id],[Nome],[Codigo],[Descricao]) VALUES (9,N'Sistema 9',N'sistema 9',NULL)
INSERT [dbo].[Sistemas] ([Id],[Nome],[Codigo],[Descricao]) VALUES (10,N'Sistema 10',N'sistema 10',NULL)
INSERT [dbo].[Sistemas] ([Id],[Nome],[Codigo],[Descricao]) VALUES (11,N'Não identificado',N'nao identificado',NULL)
SET IDENTITY_INSERT [dbo].[Sistemas] OFF

SET IDENTITY_INSERT [dbo].[Situacoes] ON 

INSERT [dbo].[Situacoes] ([Id],[Nome],[Codigo],[Descricao]) VALUES (1,N'Em análise',N'em analise',NULL)
INSERT [dbo].[Situacoes] ([Id],[Nome],[Codigo],[Descricao]) VALUES (2,N'Validado',N'validado',NULL)
SET IDENTITY_INSERT [dbo].[Situacoes] OFF
