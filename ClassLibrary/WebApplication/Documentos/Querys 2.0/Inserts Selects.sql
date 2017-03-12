/* Deu certo */
 exec CadastrarUsuario
 @Email = 'Teste@test',
 @Nome = 'joao',
 @Sobrenome = 'Silva',
 @Senha = '123',
 @CpfCnpj = '0123456789',
 @Nascimento = '2010-10-10',
 @Genero = 1,
 @Telefone = '33961179',
 @Latitude = -123456789,
 @Longitude = -154415461,
 @Complemento = 'Casa',
 @AreaAtuacao = 20,
 @IdTipoUsuario = 1,
 @IdStatusUsuario = 1

 exec CadastrarUsuario
 @Email = 'Joao@test',
 @Nome = 'Andre',
 @Sobrenome = 'Silva',
 @Senha = '123',
 @CpfCnpj = '0123456789',
 @Nascimento = '2010-10-10',
 @Genero = 1,
 @Telefone = '33961179',
 @Latitude = -123455789,
 @Longitude = -154445461,
 @Complemento = 'Casa',
 @AreaAtuacao = 20,
 @IdTipoUsuario = 2,
 @IdStatusUsuario = 1

 exec CadastrarUsuario
 @Email = 'Teste@test01',
 @Nome = 'Carlos',
 @Sobrenome = 'Silva',
 @Senha = '123',
 @CpfCnpj = '0123896541',
 @Nascimento = '1998-19-10',
 @Genero = 1,
 @Telefone = '339698541',
 @Latitude = -256463975,
 @Longitude = -49315775917,
 @Complemento = 'Apartamento',
 @AreaAtuacao = 15,
 @IdTipoUsuario = 3,
 @IdStatusUsuario = 1

 exec CadastrarUsuario
 @Email = 'ja@test01',
 @Nome = 'Jacinto',
 @Sobrenome = 'Silva',
 @Senha = '123',
 @CpfCnpj = '0123896541',
 @Nascimento = '1998-19-10',
 @Genero = 1,
 @Telefone = '339698541',
 @Latitude = -256463275,
 @Longitude = -49315774917,
 @Complemento = 'Apartamento',
 @AreaAtuacao = 15,
 @IdTipoUsuario = 3,
 @IdStatusUsuario = 1

 exec CadastrarUsuario
 @Email = 'Teste@test01',
 @Nome = 'Karine',
 @Sobrenome = 'Souza',
 @Senha = '89556',
 @CpfCnpj = '099963245178',
 @Nascimento = '1990-19-10',
 @Genero = 1,
 @Telefone = '99999999',
 @Latitude = -256496852,
 @Longitude = -49315775023,
 @Complemento = 'Casa',
 @AreaAtuacao = 15,
 @IdTipoUsuario = 2,
 @IdStatusUsuario = 2

 exec CadastrarUsuario
 @Email = 'joana@test01',
 @Nome = 'Joana',
 @Sobrenome = 'Souza',
 @Senha = '89556',
 @CpfCnpj = '099963245178',
 @Nascimento = '1990-19-10',
 @Genero = 1,
 @Telefone = '99999999',
 @Latitude = -256426852,
 @Longitude = -49315575023,
 @Complemento = 'Casa',
 @AreaAtuacao = 15,
 @IdTipoUsuario = 3,
 @IdStatusUsuario = 2

 exec CadastrarUsuario
 @Email = 'Teste@test01',
 @Nome = 'Pedro',
 @Sobrenome = 'Alex',
 @Senha = '89578',
 @CpfCnpj = '088963245178',
 @Nascimento = '1980-19-10',
 @Genero = 1,
 @Telefone = '999969999',
 @Latitude = -251496852,
 @Longitude = -46915775023,
 @Complemento = 'Casa',
 @AreaAtuacao = 15,
 @IdTipoUsuario = 3,
 @IdStatusUsuario = 1

 exec CadastrarUsuario
 @Email = 'Ana@test01',
 @Nome = 'ana',
 @Sobrenome = 'Alex',
 @Senha = '89578',
 @CpfCnpj = '088963245178',
 @Nascimento = '1980-19-10',
 @Genero = 1,
 @Telefone = '999969999',
 @Latitude = -251496752,
 @Longitude = -46915774023,
 @Complemento = 'Casa',
 @AreaAtuacao = 15,
 @IdTipoUsuario = 2,
 @IdStatusUsuario = 1

 exec CadastrarUsuario
 @Email = 'carla@test01',
 @Nome = 'Carla',
 @Sobrenome = 'antunes',
 @Senha = '89578',
 @CpfCnpj = '088963245178',
 @Nascimento = '1980-19-10',
 @Genero = 1,
 @Telefone = '999965999',
 @Latitude = -251496742,
 @Longitude = -46915774923,
 @Complemento = 'Casa',
 @AreaAtuacao = 15,
 @IdTipoUsuario = 2,
 @IdStatusUsuario = 1

 exec CadastrarUsuario
 @Email = 'carla@test01',
 @Nome = 'Carla',
 @Sobrenome = 'antunes',
 @Senha = '89578',
 @CpfCnpj = '088963245178',
 @Nascimento = '1980-19-10',
 @Genero = 1,
 @Telefone = '999965999',
 @Latitude = -251496742,
 @Longitude = -46915774923,
 @Complemento = 'Casa',
 @AreaAtuacao = 15,
 @IdTipoUsuario = 2,
 @IdStatusUsuario = 1
select * from usuario

exec AtualizarUsuario
 @Id = 1,
 @Email = 'Teste@test',
 @Nome = 'joao',
 @Sobrenome = 'Silva',
 @Senha = '123',
 @Telefone = '33961179',
 @Latitude = -123456789,
 @Longitude = -154415461,
 @Complemento = 'Casa',
 @AreaAtuacao = 20
select * from Usuario

exec AlterarStatusUsuario
 @IdUsuario = 3,
 @IdStatus = 1
 select * from Usuario

 exec CadastrarItem
 @Codigo = 1,
 @Nome = 'Carrinho de mao',
 @Descricao = 'Serve pra carregar massa',
 @ValorUnitario = 1.99,
 @Quantidade = '100',
 @IdCategoria = 2,
 @IdUsuario = 3

 exec CadastrarItem
 @Codigo = 2,
 @Nome = 'Copo',
 @Descricao = 'Serve pra carregar massa',
 @ValorUnitario = 1.99,
 @Quantidade = '100',
 @IdCategoria = 2,
 @IdUsuario = 4

 exec CadastrarItem
 @Codigo = '90',
 @Nome = 'Garrafa Térmica',
 @Descricao = 'Serve pra manter o café quente',
 @ValorUnitario = 100.00,
 @Quantidade = '5',
 @IdCategoria = 4,
 @IdUsuario = 3

 exec CadastrarItem
 @Codigo = '20',
 @Nome = 'Coca',
 @Descricao = 'Serve pra manter o café quente',
 @ValorUnitario = 100.00,
 @Quantidade = '5',
 @IdCategoria = 3,
 @IdUsuario = 6

 exec CadastrarItem
 @Codigo = '44',
 @Nome = 'Guarana',
 @Descricao = 'Serve pra manter o café quente',
 @ValorUnitario = 100.00,
 @Quantidade = '5',
 @IdCategoria = 3,
 @IdUsuario = 6

 exec CadastrarItem
 @Codigo = '4',
 @Nome = 'Dolli',
 @Descricao = 'Serve pra manter o café quente',
 @ValorUnitario = 100.00,
 @Quantidade = '5',
 @IdCategoria = 3,
 @IdUsuario = 6
 select * from Item

 exec AtualizarItem
 @Id = 1,
 @Codigo = 990,
 @Nome = 'Play 3',
 @Descricao = 'Serve pra joga',
 @ValorUnitario = 2200.00,
 @Quantidade = '50',
 @IdCategoria = 5
select * from Item

exec DesabilitaritemPorId	
	@Id = 2
select *from Item

exec DetalheUsuario
 @IdUsuario = 2
select *from Usuario

exec ListarItem
 @IdUsuario = 3

exec ListarPedido
@IdUsuario = 3

exec ListarPedidoPeloStatus
@IdUsuario = 1,
@IdStatus = 1

exec RealizarPedido	
@CodigoPedido = 2,
@IdVendedor = 4,
@IdComprador = 2,
@IdStatusPedido = 2
select * from Pedido

exec InserirItemPedido
@IdPedido = 7,
@IdItem = 4,
@Quantidade = 5
select * from ItemPedido


select Item.Nome, Usuario.Id, Usuario.Nome, TipoUsuario.Nome, Pedido.Id, ItemPedido.* from Item
inner join Usuario on Usuario.Id = Item.IdUsuario
inner join Pedido on Usuario.Id = Pedido.IdVendedor
Inner join ItemPedido on Item.Id = ItemPedido.IdItem
inner join TipoUsuario on TipoUsuario.Id = Usuario.IdTipoUsuario

select Item.Nome, Usuario.Id, Usuario.Nome, TipoUsuario.Nome, Pedido.Id, ItemPedido.* from Item
inner join Usuario on Usuario.Id = Item.IdUsuario
inner join Pedido on Usuario.Id = Pedido.IdComprador
Inner join ItemPedido on Item.Id = ItemPedido.IdItem
inner join TipoUsuario on TipoUsuario.Id = Usuario.IdTipoUsuario




