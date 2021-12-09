-- Listagem das Especialidades
SELECT especialidade [Especialidade] FROM ESPECIALIDADE
GO

-- Listagem dos Médicos
SELECT	crm [CRM], 
		nomeMedico [Nome], 
		sobrenomeMedico [Sobrenome], 
		email [Email], 
		especialidade [Especialidade], 
		nomeClinica [Clínica] , 
		cnpj [CNPJ], 
		razaoSocial [Razão Social], 
		enderecoClinica [Endereço] 
FROM MEDICO M
INNER JOIN ESPECIALIDADE E ON (M.idEspecialidade = E.idEspecialidade)
INNER JOIN CLINICA C ON (M.idClinica = C.idClinica)
INNER JOIN USUARIO U ON (M.idMedico = U.idMedico)

-- Listagem dos Prontuários
SELECT	nomePaciente [Nome],
		email [Email],
		dataNascimento [Data_Nascimento],
		dddTelefone [DDD],
		numeroTelefone [Telefone],
		rg [RG],
		cpf [CPF],
		lugadouro [Lugadouro],
		endereco [Endereço],
		numeroEndereco [Número],
		bairro [Bairro],
		cidade [Cidade],
		uf [Estado],
		cep [CEP]
FROM PACIENTE P
INNER JOIN ENDERECO E ON (P.idEndereco = E.idEndereco)
INNER JOIN USUARIO U ON (P.idPaciente = U.idPaciente)

-- Listagem das Consultas
SELECT	nomePaciente [Prontuário],
		nomeMedico [Medico],
		sobrenomeMedico [--],
		datahoraConsulta [Data_Consulta],
		descricao [Situação]
FROM AGENDAMENTO A
INNER JOIN PACIENTE P ON (A.idPaciente = P.idPaciente)
INNER JOIN MEDICO M ON (A.idMedico = M.idMedico)
INNER JOIN SITUACAO S ON (A.idSituacao = S.idSituacao)