﻿CREATE TABLE [dbo].[NewsFeeds] (
    [id] [bigint] NOT NULL IDENTITY,
    [departmentid] [bigint] NOT NULL,
    [title] [nvarchar](max),
    [description] [nvarchar](max),
    [isactive] [bit] NOT NULL,
    [createdonutc] [datetime] NOT NULL,
    [updatedonutc] [datetime],
    [ipused] [nvarchar](20),
    [userid] [nvarchar](max),
    CONSTRAINT [PK_dbo.NewsFeeds] PRIMARY KEY ([id])
)
CREATE INDEX [IX_departmentid] ON [dbo].[NewsFeeds]([departmentid])
ALTER TABLE [dbo].[NewsFeeds] ADD CONSTRAINT [FK_dbo.NewsFeeds_dbo.Departments_departmentid] FOREIGN KEY ([departmentid]) REFERENCES [dbo].[Departments] ([id])
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201805301947381_addnewsFeedTable', N'EmployeesPortal.Web.Contexts.EmployeePortalMigration.Configuration',  0x1F8B0800000000000400ED5D5B6FDCB8157E2FD0FF20CC535B78677CD90DB681BD8BAC1DB74613C7889D6DDF0C59A2C74234D2AC2E898D627F591FFA93FA174A4AA4C4BB4889D2CC0483008147243F1E1E9E0B4552E7FCEF3FFF3DFDF979157B5F4096476972363B9A1FCE3C9004691825CBB359593C7EF7E3ECE79FFEF887D3B7E1EAD9FB95D43B41F560CB243F9B3D15C5FAF56291074F60E5E7F3551464699E3E16F3205D2DFC305D1C1F1EFE757174B400106206B13CEFF4639914D10A543FE0CFF33409C0BA28FDF87D1A8238C7CF61C96D85EA5DFB2B90AFFD009CCDDEAED671FA02407E9366851FCFFF091EE6B07D019E8B7CE6BD89231FD2740BE2C799E727495AF805A4F8F5A71CDC16599A2C6FD7F0811FDFBDAC01ACF7E8C739C02379DD56371DD4E1311AD4A26D48A082322FD29525E0D109E6D2826FDE8BD7B3868B908F6F21BF8B1734EA8A9767B30BB0F6B362059262E6F1DDBD3E8F3354B56636C5EBF33403F3B6E58127293F68A4040A13FA77E09D97715166E02C016591F9F18177533EC451F00FF072977E06C95952C6314D2DA41796310FE0A39B2C5D83AC78F9081EF118A270E62DD8760BBE61D38C6A538FED2A295E7D3FF3AE61E7FE430C1A61A0F8705BC001FD0D2420F30B10DEF845013238975721A8D829F4CEF595C0FF496F50FAA04ACDBCF7FEF33B902C8BA7B319FC73E65D46CF20244F30059F92086A206C546425E8EA24CAFDA088BE341DFD92A631F013C9C0F4384106D020D3A42C028275019FDC4568109660E53AD480750C685DE620D4F0EDF8D001DB601F59A4EBA5E7EC5CFB5FA265253D5C8737690E55ED2388ABC2FC295AD7666A8E0AEE6975BCCCD2D5C734C66DA8A2FB3B3F5B0258E32E9597DFA6651658D274010A3F8A9594D5C51AFA840A522AC55A325A4F17AD9DD25AAF9A9976760BB5D95B2CBD56C03AF1F8262B78F2D790AEFB24A54676726C6D6572E067C113A4F16B9A85F9E8645F803CC8A275ED9077C4AA878DC2758B911E690DD5278042B54CB397A1587B5F33AEAFA1ADF5308F43ACB4CAE3105B6FE371CEB11429692315EE6B33CF52C7144A7D0D5B63B09F69C9B5F737A4EDDEEFEC57CA7BEBE562A56C611B64B64B6E3D7ADB06B278B6B70C75CBBD5DD8C5E50BC21A8A01F036D6189A25D8BD7B68B1C2A1660FC294490825B3F093C1608F11C4B9FF12E551718F0CE0603B1AFB6EF1F6467EE34BD41E5B0F3293AFDEA070E29030BCCC1D51453ACA94AE68F0429AEAA0ADABA4B1F18D1DB436F506B9CF6BF035BF0448B2ED9C2769B7779D53B9CE693685C21DDC5DD93B898D3A09620A142E42522C9836599D41668DA82782D799B6F7CDD1DD9B7C7D0D8A396938AF212F3308F735CD3ECF69C403CFB85D6B0A8F4D4DE1C9D1C3E3C98F3FBCF2C39357DF83931FFA98C5AB1E66F14A275347C73F1AC994A5B65DEB771C8E7F78E5A457A5687F82BA944BA59A9EEF7B5CAD156AB1549069491527228DA0DC8B3541DD7ED146948AE22DAD8A06D447134817536B03A177DC7E8D25EECD7A0D27AF122DC491AE25227F1DA4BE4432E750EA05235777C205E3AE58C6B7AB6A4B6BB06934E8E53C4D1EA36C05066F27DCF8798E0E01FFEEE74FA3AF1E6F41506650606F0B7FB51EBDB79BA73401D7E5EA01E9C1747D399B9ABBAFE9255C6DA7D9DB04B51A8CF72E0D3EA765F13609D1E2F893FD5AB9017042CE9B2000797E09851984E7698956A0438EB491A1DAF4D2E43CF6A3957C6DC299D47B52B55D9FC86B086B144535DB5D9077E9324ACC482555D5A4D6353A49C5D56C4945606694E29A6A42AB0A9D74D6B59CADFCAA1972BFF4AB60B77FED37CC79AB6C81BBDD9E4D2D1CABE9439D8EEE9BAA9E7EF5E3D27557BDB4A13202EEB5A182DD7E6DA8C8848FBF44215A9518BC1091CA10DEA8BEFC5DAB5BE738CAA65607669853773E8D0D50A9CB9B3C4F83A8D202EA8882DE9A6389870B38AFE3CE513D0E7298018702453B424E0E767F36FB8BC00F3564734DA885A4F70C59E0230118CA25C89006FAE89525877A15258528C45112446B3FD6D3C035333C5B407C6F3AE04B602720411642CF50939ED953039186A62B4E2FBB3874BAA0E4A35B6CD85B1EBA59565CF96045A73DFCEA9A691DB84488CCE4B2B7F8480737910049C76ED2377FD3626342249E1FEBE65A7398CCCE37B9F363678D34D7E427B6494A4A26122C25A377C83ED187FE06B3AEB34D83C4C9C62EB917215BCBE04E786CED21B9B1B50D02D33823C3F915AF65381620E13E476FEFE942A0786AA6172C9EE13BE3F464E7E12A19D01E8EB7F3DFDED231172FDD99FA94CE4E43C70442A561F08E383AC941B46ACA75A7D2ED8CB37723CC97E29A036D097A7B4C3DCABA5C3D549369959E1F9B0B959A13269DCB4FA5279226C5D1816ACEBBCE11DA79170E8BCD05ABE31442215C78277C14E9D20F7B0209D3B3C48400E535894D48193EF5311500FE08681429E30E90145286779827913276D81B903296253B2765F5899DE9FC73C777A3C8187BF837BD97D48E790302C6F063CBE4ABDE4F47316C600B90893276F18003DC480E9C209DF8CC29C7DBF7BC8820F05B5048AED4B61BF99225B9206A2C4EBDC32020D48F0DDAB62F95528CB6D8008BBC014B914861074EFBA223A0B4451D18F8E05E0060D7BD1D20BC82EA005B25EE00C5D7480520C1E2581047EE7E68A9C36B250B58724F430B8B9D23074BE9172B20CC0571AA96E27B785EE5BB8FAA9A0111C510CC46F7D91485A1D1C3053B484306705FCDCA59A03974313C76E1D8A05262C373960EA6F66485E4AB32393B3A8E0F2C0E10B881C82D92C589C19892C27CCEA6658C8194C8B6BF0731633AF960E5B79311F24D5DAB6DDDC18C11F6710DD5B107A3A45FDE884CEADC9034DE92A486A272C7C67B9063A98FECC30D91275DBB6AA6FB6AD428F03241C30ECD0E1A8523597A0C668AEAC6A8C818930D229B2D226A607832340CEAD8095230890CC63997C822A89B4BB20D0E9B2D8E415CE27632145C228371CE252CA3DD4C92BC9F5BBCA10F6211FB22EE48D9C81DACE69DB1293B5DD41153F183D38522B4EAE97B7FBD8E9225156A153FF16EEB38ABE7DFDDDA871D5DD5188B80E136FF86DBF454A499BF045C29EC1A527A8902445CF885FFE0A31B68E7E14AA8267D4356BC68902E8597607126C96B076982FE26DFACA843CFCED5982D6F2FE170518D6AE440EE8784C61E8A82EBC77E26F998FC3C8DCB55A23EAF52B74EAA8F0CE8F6F5137384F6236A868AE6A93912FB19358DC6969823B2DF52D3886C89C568F117D6CC58F1330BBAF017D40C45F8998872BAE0E446D88B12A495B320BCFC1B69876261DF532F6468061A216F368E2EE0000734007E6421C3544C4B4682A9E7E6687C644B1A912F3347650258D2904CC1262C007BDA4DA3E9CFC1D588FC850C1AB3EBB2866696F7966ADB2C95E6CD7B80C552A11A5A2E75F3BD37DFEBC8E43A82F7929C6A881CD3503F548DC7D18E5DF12EE4962A8F6687424716A491E8E7367601070F64CD027E688543470FE4D0E822734C3188200D2B969A230BD1046960A1706F1B77D436365BC9CE2CA30AD1C02EAA9BEE8A5574F11E15AADE51C24DBFA3EC7577AB7457B5A7DB5371993B1AF6CAAB6FAE62F415C7E46A4CB25B476A886B61E57FAD58F96F689EC47D6EE773D65C83E93F6F6A0815E3C905319AF5AA4B636A1472259B970239CA86A650754AD973DAF84B47F6B3D68960AA70D5C8EC660C87C7A251F0234B0C2AC29200469599A3B241B0684CB6C41C918B74454372451654D2F1AC1822E9825E780A8ECA6B98F72046B0A2D1C5527364492C2B1A5A52DC035B42335F668E2A097745034B8ACDB1DBD857BC8A6EB14B53DE5270E0D3EACB93C39C9A02C3C640D643B4B3926EBC23155D8806A21E5B62E1F84102187EBE9512A6BCE1E140C2EA7BB4C3244C81A1B64B4C841ED62C69C30AA93199B03B8CE9D7851D52E3D949EFA832225CF5E0AB34BDE327CDEFE6AA07BE66D19D5A57B87751579979848DD0EDBFE40558CD5185F9ED6FF1791C5577E74885F77E123D82BCA8434DCD8E0F8F8EB99CBCDB931F7791E7612CB9A64245FC527E473D41868087082A03646D676038CB2851F5C150DD47F2051D25FBD99F56FEF39F69A43E41F41FA2C249007DB4F351B80AA02F03331A1C13509FF04908A96F074AF650AC996F9717F59B11D5824E3C314856C58CA315C14EF28D0E224C925374E34A29CB1C42A658F8FEEC2A09C1F3D9ECDF55DBD7DED5BFEEE9E607DE870CBA85D7DEA1F7BBA3945D1694B0008368D91B2AF7864A110867870DD6DEB77EE3222BBBB7B0CB02BB37F5725A7AD330B06F312BE44033C2647EEC6345A4591FFB00A9323EF636498A8C8FBDF1F6F6D2ADBD94DF67D85BCBE1D6D2DD7B9124E9DE7EDDF28DE9A1FA6A82992E2A2E25742B64D350C3B02A24F980D46D2D689702226AD05FD5E303EF2AFF9444BF95B0E00EB21629219F62C54D2A2B83E4690DA1BFEF4456327396439B573765ADDDC0E9677395595153371D404DEF0C663D27B697DE350D1DEB1D93184C6EFE58BDE99F07AC8FDF90E5001BE4CCA479BE06214A7279B9C273C24255AEAE3E58CA3C5D7DDDAF3C6F571FD29439BBFA6C0AB7F7136C0D1269B9418F24B91D606E9C54F702CC2C54DB9AE2BDEB15FB76792E2159D220E51713228DB97AA4A26E395EC0EC58322167EEF446CC15E40C7B9372EF3E41101DA5870A086713409C0D9A34550E176D4C08935D0FCF368CFDAEC416EF97E4C759629F4D24F1D92A11D88A7C0576497A9C5B0112618D1305D37C1A3B621194DFE96EAD5D304DAED323E3CDE605C05843A79DFA9D4B90E3DC256C4A18A6760F9642B171276193D4C6A98B68E34C5250E6F97076C03D683E56DE4AE7D033218DD31C34ED3EBE0474E4A0FA1DDFA81A1FDD580989C14796A6270D1389C9B04C33AE323248A2A02B2466C27C32C6A90F5C4A8DEA33268BB3ACED4F1D3386D8E0FD3685D84C9820662362A3FA3669CBC5C62A17CC1852B329EFB40D3263ECA0261419EEFB2DB27B2FC4B8E5E7167F12D67C286098B7A5FE660BAED71ED0B70EF52E6D5B2E4619E63BD226769181A3123358E39C2FAA6E708D48122C59D69F515E18555F75797747468963649D90D2EE2ED835ABD00D5B2CEB4A1E5F5AD54D6B27945DB55564DDA9435AF35D0A264FE851A8A1EAD06E7C78CDA51D20AEA3EA5011FC5DD72B76D9DA5E711D55AF8A60EAE3A7BE110D50470605C97E1DD5CE61C68ED192DBF44F68B353C96B86CF2C6B683B52986C43621AFB8C4D130FD17DEA99E1423D360B46492A334CB879E7AE4D40B37D2963A409276409E33A5E2624286DE160264C972286194947EEBBAECD1C054FE409EFB639238C13A6302B1B458810F74C192B018C1396B8541D8B842F62B40FF8EE5A26E8C665FDEB02E4D1B285388598090898B7D6A6CE55F2989297678E225285BB79F41E7A8310BED2BEC98AE8D10F0A588C2E5B46C972E65597D5D095DF07105E251FCA625D1670C860F51033DE07BD84EBFAAFB2DAB0349F7EA83E62C95D0C019219A14BAA1F925FCA280E1BBA2F25779D1410E8ED1E5F63447359A0EB8CCB9706E93A4D0C8130FB9A4D893BF4852004CB3F24B73EFACEC69E36287EEFC0D20F5EDA9B6D2A90EE8960D97E7A11F9CBCC5FE518A36D0F7F42190E57CF3FFD1F4CB5F5E375BE0000 , N'6.2.0-61023')
