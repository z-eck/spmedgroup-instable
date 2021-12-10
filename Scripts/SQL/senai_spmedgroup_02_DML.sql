USE SENAI_SPMG;
GO

INSERT INTO SPECIALTY (specialtyName)
VALUES ('Acupuntura'), ('Anestesiologia'), ('Angiologia'), ('Cardiologia'), ('Cirurgia Cardiovascular'), ('Cirurgia da Mão'), ('Cirurgia do Aparelho Digestivo'), ('Cirurgia Geral'), ('Cirurgia Pediátrica'), ('Cirurgia Plástica'), ('Cirurgia Torácica'), ('Cirurgia Vascular'), ('Dermatologia'), ('Radioterapia'), ('Urologia'), ('Pediatria'), ('Psiquiatria');
GO

INSERT INTO CLINIC (clinicName, cnpj, corporateName, clinicAddress)
VALUES ('Clinica Possarle', '86.400.902/0001-30', 'SP Medical Group', 'Av. Barão Limeira, 532, São Paulo, SP')
GO

INSERT INTO USERTYPE (userTypeDescription)
VALUES ('Administrador'), ('Medico'), ('Paciente');
GO

INSERT INTO USERS (idUserType, email, passwd)
VALUES (1, 'admin@spmedicalgroup.com.br', 'admin132'), (2, 'ricardo.lemos@spmedicalgroup.com.br', 'ricardo132'), (2, 'roberto.possarle@spmedicalgroup.com.br', 'roberto132'), (2, 'helena.souza@spmedicalgroup.com.br', 'helena132'), (3, 'ligia@gmail.com', 'ligia132'), (3, 'alexandre@gmail.com', 'alexandre132'), (3, 'fernando@gmail.com', 'fernando132'), (3, 'henrique@gmail.com', 'henrique132'), (3, 'joao@hotmail.com', 'joaao132'), (3, 'bruno@gmail.com', 'bruno132'), (3, 'mariana@outlook.com', 'mariana132');
GO

INSERT INTO MEDIC (idUser, idSpecialty, idClinic, medicName, medicLastname, crm)
VALUES (2, 2, 1, 'Ricardo', 'Lemos', '54356-SP'), (3, 17, 1, 'Roberto', 'Possarle', '53452-SP'), (4, 16, 1, 'Helena', 'Strada', '65463-SP');
GO

INSERT INTO LOCALADDRESS (place, addressName, district, city, fu, cep)
VALUES ('Rua', 'Estado de Israel', NULL, 'São Paulo', 'SP', '04022-000'), ('Avenida', 'Paulista', 'Bela Vista', 'São Paulo', 'SP', '01310-200'), ('Avenida', 'Ibirapuera', 'Indianópolis', 'São Paulo', 'SP', '04029-200'), ('Rua', 'Vitória', 'Vila Sao Jorge', 'Barueri', 'SP', '06402-030'), ('Rua', 'Vereador Geraldo de Camargo', 'Santa Luzia', 'Ribeirão Pires', 'SP', '09405-380'), (NULL, 'Alameda dos Arapanés', 'Indianópolis', 'São Paulo', 'SP', '04524-001'), ('Rua', 'São Antonio', 'Vila Universal', 'Barueri', 'SP', '06407-140');
GO

INSERT INTO PATIENT (idUser, idAddress, patientName, birthDate, dddPhone, phoneNumber, rg, cpf, addressNumber)
VALUES (5, 1, 'Ligia', '13/10/1983', 11, '3456-7654', '43522543-5', 94839859000, 240), (6, 2, 'Alexandre', '23/07/2001', 11, '98765-6543', '32654345-7', 73556944057, 1578), (7, 3, 'Fernando', '10/10/1978', 11, '97208-4453', '54636525-3', 16839338002, 2927), (8, 4, 'Henrique', '13/10/1985', 11, '3456-6543', '54366362-5', 14332654765, 120), (9, 5, 'João', '27/08/1975', 11, '7656-6377', '53254444-1', 91305348010, 66), (10, 6, 'Bruno', '21/03/1972', 11, '95436-8769', '54566266-7', 79799299004, 945), (11, 7, 'Mariana', '05/03/2018', NULL, NULL, '54566266-8', 13771913039, 232);
GO

INSERT INTO SITUATION (situationDescription)
VALUES ('Realizada'), ('Cancelada'), ('Agendada');
GO

INSERT INTO SCHEDULING (idPatient, idMedic, idSituation, schedulingDateHour)
VALUES (7, 3, 1, '20/01/2020 15:00'), (2, 2, 3, '06/01/2020 10:00'), (3, 2, 1, '07/02/2020 11:00'), (2, 2, 1, '06/02/2018 10:00'), (4, 1, 3, '07/02/2019 11:00'), (7, 3, 2, '08/03/2020 15:00'), (4, 1, 2, '09/03/2020 11:00');
GO
