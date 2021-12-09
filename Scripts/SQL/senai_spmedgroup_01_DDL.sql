CREATE DATABASE SENAI_SPMG;
GO

USE SENAI_SPMG;
GO

-- Todos os itens do Projeto estão em inglês, mas os comentários em PT-BR.

-- Tabela criada para se focada a especialidades dos médicos
CREATE TABLE SPECIALTY (
	
	idSpecialty SMALLINT PRIMARY KEY IDENTITY(1,1),
	specialtyName VARCHAR(50) NOT NULL UNIQUE

);
GO

-- Tabela criada para colocar as informações da clínica
CREATE TABLE CLINIC (

	idClinic TINYINT PRIMARY KEY IDENTITY(1,1),
	clinicName VARCHAR(50) NOT NULL UNIQUE,
	cnpj CHAR(18) NOT NULL UNIQUE,
	corporateName VARCHAR(50) NOT NULL,
	clinicAddress VARCHAR(256) NOT NULL UNIQUE

);
GO

-- Tabela Criada para definir o tipo de usuário logado na API
CREATE TABLE USERTYPE (

	idUserType TINYINT PRIMARY KEY IDENTITY,
	UserTypeDescription VARCHAR(50) NOT NULL UNIQUE

);
GO

-- Tabela Criada para a criação de usuários no sistema, utilizando um email pessoal ou da clínica
CREATE TABLE USERS (

	idUser INT PRIMARY KEY IDENTITY,
	idUserType TINYINT FOREIGN KEY REFERENCES USERTYPE(idUserType),
	email VARCHAR(300) UNIQUE NOT NULL,
	passwd VARCHAR(16) NOT NULL CHECK(len(passwd) >= 8)

);
GO

-- Tabela criada para inserir a imagem dos usuários
CREATE TABLE USERIMG (
	idUserImg INT PRIMARY KEY identity(1,1),
	idUser INT NOT NULL UNIQUE FOREIGN KEY REFERENCES USERS(idUser),
	binaryNumber VARBINARY(MAX) NOT NULL,
	mimeType VARCHAR(30) NOT NULL,
	archiveName VARCHAR(250) NOT NULL,
	inclusionDate DATETIME DEFAULT GETDATE() NULL
);
GO

-- Tabela criada para as informações dos médicos
CREATE TABLE MEDIC (
	
	idMedic SMALLINT PRIMARY KEY IDENTITY(1,1),
	idUser INT NOT NULL UNIQUE FOREIGN KEY REFERENCES USERS(idUser),
	idSpecialty SMALLINT FOREIGN KEY REFERENCES SPECIALTY(idSpecialty),
	idClinic TINYINT FOREIGN KEY REFERENCES CLINIC(idClinic),
	medicName VARCHAR(30) NOT NULL,
	medicLastname VARCHAR(30) NOT NULL,
	crm CHAR(8) NOT NULL UNIQUE,

);
GO

-- Tabela criada para especificar o endereço dos pacientes, desejável ser um endereço único, e se houver repetidos, apenas utilizar a ID correspondente
CREATE TABLE LOCALADDRESS (

	idAddress INT PRIMARY KEY IDENTITY(1,1),
	place VARCHAR(15),
	addressName VARCHAR(250) NOT NULL,
	district VARCHAR(100),
	city VARCHAR(50) NOT NULL,
	fu CHAR(2) NOT NULL,
	cep CHAR(9) NOT NULL UNIQUE

);
GO


-- Tabela criada para as informações dos pacientes. Adicionado o número de endereço nesta tabela, visto que é melhor deixar o endereço global, enquanto o número ser algo mais exato
CREATE TABLE PATIENT (

	idPatient INT PRIMARY KEY IDENTITY(1,1),
	idUser INT NOT NULL UNIQUE FOREIGN KEY REFERENCES USERS(idUser),
	idAddress INT FOREIGN KEY REFERENCES LOCALADDRESS(idAddress),
	patientName VARCHAR(30) NOT NULL,
	birthDate DATE,
	dddPhone CHAR(2),
	phoneNumber VARCHAR(10),
	rg CHAR(10) NOT NULL UNIQUE,
	cpf CHAR(11) NOT NULL UNIQUE,
	addressNumber VARCHAR(6) NOT NULL

);
GO

-- Tabela criada apenas para indicar a situação do agendamento
CREATE TABLE SITUATION (

	idSituation TINYINT PRIMARY KEY IDENTITY,
	situationDescription VARCHAR(25) NOT NULL UNIQUE

);
GO

-- Tabela criada para informar o paciente que será atendido, o médico que o atenderá, a data de quando foi ou será, e a situação se foi atendido, cancelado ou está agendada
CREATE TABLE SCHEDULING (

	idScheduling INT PRIMARY KEY IDENTITY(1,1),
	idMedic SMALLINT NOT NULL FOREIGN KEY REFERENCES MEDIC(idMedic),
	idPatient INT NOT NULL FOREIGN KEY REFERENCES PATIENT(idPatient),
	idSituation TINYINT DEFAULT 3 FOREIGN KEY REFERENCES SITUATION(idSituation),
	schedulingDescription VARCHAR(300),
	schedulingDateHour DATETIME

);
GO