USE SENAI_SPMG;
GO

-- Listagem das Especialidades
SELECT specialtyName [Especialidade] FROM SPECIALTY
GO

-- Listagem dos Médicos
SELECT	crm [CRM], 
		medicName [Nome], 
		medicLastname [Sobrenome], 
		email [Email], 
		specialtyName [Especialidade], 
		clinicName [Clínica] , 
		cnpj [CNPJ], 
		corporateName [Razão Social], 
		clinicAddress [Endereço] 
FROM MEDIC M
INNER JOIN SPECIALTY E ON (M.idSpecialty = E.idSpecialty)
INNER JOIN CLINIC C ON (M.idClinic = C.idClinic)
INNER JOIN USERS U ON (M.idUser = U.idUser)

-- Listagem dos Prontuários
SELECT	patientName [Nome],
		email [Email],
		birthDate [Data_Nascimento],
		dddPhone [DDD],
		phoneNumber [Telefone],
		rg [RG],
		cpf [CPF],
		place [Lugadouro],
		addressName [Endereço],
		addressNumber [Número],
		district [Bairro],
		city [Cidade],
		fu [Estado],
		cep [CEP]
FROM PATIENT P
INNER JOIN LOCALADDRESS E ON (P.idAddress = E.idAddress)
INNER JOIN USERS U ON (P.idUser = U.idUser)

-- Listagem das Consultas
SELECT	patientName [Prontuário],
		medicName [Medico],
		medicLastname [--],
		schedulingDateHour [Data_Consulta],
		situationDescription [Situação]
FROM SCHEDULING SC
INNER JOIN PATIENT P ON (SC.idPatient = P.idPatient)
INNER JOIN MEDIC M ON (SC.idMedic = M.idMedic)
INNER JOIN SITUATION SI ON (SC.idSituation = SI.idSituation)
