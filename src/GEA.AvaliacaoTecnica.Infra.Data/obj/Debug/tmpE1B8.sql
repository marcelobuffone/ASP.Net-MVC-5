CREATE TABLE [dbo].[Competencias] (
    [Id] [uniqueidentifier] NOT NULL,
    [MesAno] [datetime] NOT NULL,
    [ValorBruto] [real] NOT NULL,
    [ValorLucro] [real] NOT NULL,
    [EmailEnviado] [bit] NOT NULL,
    [QuantidadeEmailsEnviado] [int] NOT NULL,
    [Situacao] [varchar](50) NOT NULL,
    [EmpresaId] [uniqueidentifier] NOT NULL,
    [DataCadastro] [datetime] NOT NULL,
    CONSTRAINT [PK_dbo.Competencias] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Empresas] (
    [Id] [uniqueidentifier] NOT NULL,
    [RazaoSocial] [varchar](100) NOT NULL,
    [Email] [varchar](100) NOT NULL,
    [DiaVencimento] [int] NOT NULL,
    [Foto] [varchar](100),
    [DataCadastro] [datetime] NOT NULL,
    CONSTRAINT [PK_dbo.Empresas] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Usuarios] (
    [Id] [uniqueidentifier] NOT NULL,
    [Nome] [varchar](150) NOT NULL,
    [Ativo] [bit] NOT NULL,
    [EmpresaId] [uniqueidentifier] NOT NULL,
    [DataCadastro] [datetime] NOT NULL,
    CONSTRAINT [PK_dbo.Usuarios] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Registros] (
    [Id] [uniqueidentifier] NOT NULL,
    [HoraEntrada] [datetime] NOT NULL,
    [HoraSaida] [datetime] NOT NULL,
    [ValorTotal] [datetime] NOT NULL,
    [Codigo] [varchar](50) NOT NULL,
    [VeiculoId] [uniqueidentifier] NOT NULL,
    [EmpresaId] [uniqueidentifier] NOT NULL,
    [DataCadastro] [datetime] NOT NULL,
    CONSTRAINT [PK_dbo.Registros] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Veiculos] (
    [Id] [uniqueidentifier] NOT NULL,
    [Placa] [varchar](100) NOT NULL,
    [Modelo] [varchar](100) NOT NULL,
    [Marca] [varchar](100) NOT NULL,
    [DataCadastro] [datetime] NOT NULL,
    CONSTRAINT [PK_dbo.Veiculos] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_EmpresaId] ON [dbo].[Competencias]([EmpresaId])
CREATE INDEX [IX_EmpresaId] ON [dbo].[Usuarios]([EmpresaId])
CREATE INDEX [IX_Id] ON [dbo].[Registros]([Id])
ALTER TABLE [dbo].[Competencias] ADD CONSTRAINT [FK_dbo.Competencias_dbo.Empresas_EmpresaId] FOREIGN KEY ([EmpresaId]) REFERENCES [dbo].[Empresas] ([Id])
ALTER TABLE [dbo].[Usuarios] ADD CONSTRAINT [FK_dbo.Usuarios_dbo.Empresas_EmpresaId] FOREIGN KEY ([EmpresaId]) REFERENCES [dbo].[Empresas] ([Id])
ALTER TABLE [dbo].[Registros] ADD CONSTRAINT [FK_dbo.Registros_dbo.Empresas_Id] FOREIGN KEY ([Id]) REFERENCES [dbo].[Empresas] ([Id])
ALTER TABLE [dbo].[Registros] ADD CONSTRAINT [FK_dbo.Registros_dbo.Veiculos_Id] FOREIGN KEY ([Id]) REFERENCES [dbo].[Veiculos] ([Id])
CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId] [nvarchar](150) NOT NULL,
    [ContextKey] [nvarchar](300) NOT NULL,
    [Model] [varbinary](max) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
)
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201801200337493_AutomaticMigration', N'GEA.AvaliacaoTecnica.Infra.Data.Migrations.Configuration',  0x1F8B0800000000000400ED5CDD6EE33616BE5F60DF41D0E522B59C192CD00DEC161927E9063B49A67112F46EC048B443AC44A91215245BF4C97AD147DA57D8234BA2489194F567D7D914B94928F21379F89DC343EA63FEFBDBEFB3EF5F02DF7AC67142423AB78F2753DBC2D40D3D42D7733B65AB6FBEB5BFFFEEAF7F999D7BC18BF550D6FB98D583963499DB4F8C45278E93B84F3840C924206E1C26E18A4DDC307090173A1FA6D37F38C7C70E06081BB02C6B769B524602BCF903FE5C84D4C5114B917F157AD84F8A7278B2DCA05AD728C049845C3CB77F383F9D9C3E239F20178577D8A5C445934BBA8AD1E40C3134012C865F986D9D4215E8DE12FB2BDB4294860C31E8FCC97D82972C0EE97A194101F2EF5E230CF556C84F7031A893AA7ADBF14D3F64E373AA8625949B262C0C3A021E7F2C0CE6D49BF732BBCD0D0A263D07D3B3D76CD41BB3CEED45184498C1AC13645BF5F79D2CFC38AB6B30FC19D42574924FDB44403AB21AEA1F712601E1B29F236B91FA2C8DF19CE294C5C83FB2BEA48F3E71FF855FEFC27F633AA7A9EF8BC38081C033A9008ABEC4618463F67A8B57C5E02E3DDB72E4764EBD216F26B429C69C12F8FD1ADE8D1E7DCC49E23436BFC2C9290D4B082025BE03AE778679407E187F8A53C6A196E0947E4FA0CF29F06320D039CC9D7F4E9F09D0AB84FA14863E46B433D68F29021E7AC8C31BD4A4067B49D9C70F9D4197046208B08D8F93C53052DBBA422F9F315DB3A7B9FD77085C17E4057B6541017C0FF40412CF6D16A77D2C13C53841038993C5AF05F250C2E21EF4B946CF64BDF1597DE76CEB16FB9BE7C91389F2C0287AEC575EEF220E83DBD0974343F9F8EB324C63175E7F179AEBDCA1788D99DCC59953459EC678C4FB3128161528EF380EDDA2FFA07019C2BCF80D0E713CDD91478057EFFFB567043D64540C30650383C945C89A0249DB01FC212E7F9FA4282661A2F5F9E2A1CEDF6B8FB81F97BE5E7F5EC6825E7E5E800DF4F302E51DFBF9759871C54CD4DD2C79A78C3C0FCE02DEECBAD9C187EAEBA5C9C77AF9D02D5E937CD8839CA88479C75EF4CF304660DE1878343875CFB096888C80B4C9DDEF604AFDC1500BD8D4AFF79F1A3F60E2A67E387076DE6CA0283D4B1729EACF9450A154D0C58AA69E15C66FEE19AFA4E959F1CCDCB3B2C2A028C67B3028881528EF38867DF161C4FB4FBA37F61F2357EEFA5E14FF11C31D10454C1E719A24D93E2DA3BC9C1CF3B021F7E89C7AD6966C23378A90AB806980E924026E430FE6F6DF94719A51F93EA042E5F14C463D5650C123700CDB31D8862E2000818F11CA54F721B06B8B90DFDC815AB3967E97D99DBFA0FEE40C47987AD0BF6683B679B3B048A91DE0EFA985846DE6993902399A39A33BCC31CD70E3C94E35CBD2D9707BFE349D09ED8D430D9DD8038F1A0CFC16B8A4E42DA6A936E6287DE6B9015643CE6AF3B313FE9846B607F29846DFFFD5FBA44C99CE6D9DDB7AF228CC2D4F097B5046495AF74F99DAC8F64999DAE80F883279EE937DA08516382E0F926A993AFF80AB6C06EE135CEC07922275AB5321C35F62A6AE87896D5599976E6D53582543157EA883E1C16D0B447526AB40F00C6D0B4439C73A8C8AD95B400A7EE830B8D3D52084F954C6536D6C855A8653B23AC5B6A7B1BCF3A2FD14AA6E4F5C059C6A2AEBBB3379982D4CA0FD7AA69A616B5ED63A3313862193BBC1244DB9D86ECCA29E79A83669CE2FDA65182D7ADF2EA7108004171BCF0EDCAF1AECA05D34DB2D9B42F72BE76E6387FA4239D00EE5EE964778FE6CE6E4429EA260E618143FB32B1445B08D1714404589B5CCE53F8B6F96DD2530418EE1B8894609C37BCBDFC4C218AD71EDE9E600155F903861D901C023CAF6F60B2F50AA99D63343542EDFAA59B2D4192CE375D928FB3D6FD85216252D7A6A6A50E05EC0F8B32FA81B53607DD0515B5B995C0BF928D61C6A2D423F0DA839DB30B72ED534224259D61E4514D38848627947B44251A3A015E5EDD164598D88273F698F6814D788E0C64AEDDF53E96D44E0AAB48B0DF87657368071176CC692CFE74438F9898A38736A0EA0E4C48A0BD66263DDAD5B393D5FBC76E1F086F5B585B31B5BEEC6D125B98A08233DE8E8561A7FEA4425594E2271497ED41E33D795885079C9FF31C179EABE0B82979BA7EE0437B6DC0DC1739D86D83E2F698F50682E4488A2E8CF48DB8A885556BB0B26F22D78772A9A9BEE868B92DA4184911E74C32B140F75B4A2B8637655681E94ECAA286F8F56CA1E44A4B2AC439F2A1583D4A5AAF84F0F6CE5817C83BA0B0734ECA15BF89FB1E56EDCAFF8502F0214451D3646C55777696354947540C9BFA14B2079D19B27A1721C51AFC2DFCE8F256AC70FB3E22860FBAD24E56C20AF625B60AA67E265E702CBD784E12027ECF2677FE113186F55E10A51B2C209CB4527F687E9F4DBDA1DA6C3B94FE42489E76B8E525A5F2ABAA41E7E99DBBF58BFEE5F599352F2738A49F66183AC088E07DEEFF110C36C9CFB3D31CE96B6C1B77B7AC1E8EEF63C1236F6BD1E42BB43D66FF53C437C7A42B1A25D1C2A29548961E66D0671625DFEF495A31C593731B8F1893505528F21296A49AC11AED5BC696FD4DC72D11164A3051B7287652C50ED0D953E6E21DE4F69D1B9BEB751C6A6A1F9D6C79BA6A17809433B1B3D229474C5A24F307E6F21AEE136C46191AB85D5079A5B739DA177A6A25C671896F348D7197A43C9D71946CA0994CB0A83E3420B173C4047320BF20FCB8F86E8E3C75AD065F5FB68A8A2B67DB4DC637CEAF457AEF37C74985094E7137D14EFBD447EE62F6ABB12A3BF09C57017F5F948732F1D32F455AD1F3A079A151B87C783D6CAF1914850257D2D74BED3C96424A9EF1E19D0F05DE92DCABF7972318EDC7BCFF36EFEC6F02EE65DAFE156A571868F41BAD3E16661767E900E79CA6336D3797ED2A47D3549B79B94DBBA7718F5B0065D7793AC5B876F92331B45DF8D9A6FDD1BCC124E8324BC4911AE7B81496CBA07BD786D5225BD520B7DB84E587EA87AF0BE43D5F898A2E13C38AD77DFC1D69D4416551C9C94BBE670D227E87D0CB383525BFD040AAB87F0EF1B61D54AC8BA82C8FE9923C5AEB46EF03A977415964B57AD476515E5631B830D2B43A731ECF991CBE0B18B936473D5FB01F9E986338FD8BBA437298B520643C6C1A3FF2A1A235B069BDEBF91A3CB7D9EDD449B7F9730C610A09B24DB65DFD04F29F13DDEEF0BCD2EDB0091ADAF3F6028CFE712966B86D7AF1CE93AA42D810AF3F1B4E00E07910F60C90D5DA267DCA76FF709FE8CD7C87D2DBF649B41B64F846CF6D91941EB1805498151B5873F81C35EF0F2DDFF004205271CC5540000 , N'6.2.0-61023')

