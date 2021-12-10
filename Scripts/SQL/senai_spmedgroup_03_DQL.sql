USE SENAI_SPMG;
GO

-- Listagem das Especialidades
SELECT specialtyName [Especialidade] FROM SPECIALTY
GO

-- Listagem dos M�dicos
SELECT	crm [CRM], 
		medicName [Nome], 
		medicLastname [Sobrenome], 
		email [Email], 
		specialtyName [Especialidade], 
		clinicName [Cl�nica] , 
		cnpj [CNPJ], 
		corporateName [Raz�o Social], 
		clinicAddress [Endere�o] 
FROM MEDIC M
INNER JOIN SPECIALTY E ON (M.idSpecialty = E.idSpecialty)
INNER JOIN CLINIC C ON (M.idClinic = C.idClinic)
INNER JOIN USERS U ON (M.idUser = U.idUser)

-- Listagem dos Prontu�rios
SELECT	patientName [Nome],
		email [Email],
		birthDate [Data_Nascimento],
		dddPhone [DDD],
		phoneNumber [Telefone],
		rg [RG],
		cpf [CPF],
		place [Lugadouro],
		addressName [Endere�o],
		addressNumber [N�mero],
		district [Bairro],
		city [Cidade],
		fu [Estado],
		cep [CEP]
FROM PATIENT P
INNER JOIN LOCALADDRESS E ON (P.idAddress = E.idAddress)
INNER JOIN USERS U ON (P.idUser = U.idUser)

-- Listagem das Consultas
SELECT	patientName [Prontu�rio],
		medicName [Medico],
		medicLastname [--],
		schedulingDateHour [Data_Consulta],
		situationDescription [Situa��o]
FROM SCHEDULING SC
INNER JOIN PATIENT P ON (SC.idPatient = P.idPatient)
INNER JOIN MEDIC M ON (SC.idMedic = M.idMedic)
INNER JOIN SITUATION SI ON (SC.idSituation = SI.idSituation)
