import axios from 'axios';
import { Component } from 'react';

export default class Especialidades extends Component {
    constructor(props){
        super(props);
        this.state = {
            schedulingList: [],
            scheduling: '',
            idChangedScheduling: 0
        }
    }

    searchScheduling = () => {
        console.log('Chamada para API -->');

        // axios('http://127.0.0.1:5000/api/Especialidades')
        fetch('http://192.168.5.171:5000/api/Schedulings')

        .then((response) => response.json())

        .then((data) => this.setState({schedulingList: data}))

        .catch(error => console.log(error))

    }

    componentDidMount(){
        this.searchScheduling()


        //
    };

    updateSchedulingField = async (event) => {
        console.log('Atualização de Estado')
        await this.setState({ scheduling: event.target.value});
        console.log(this.state.scheduling);
    };

    createScheduling = (event) => {
        event.preventDefault();

        if (this.state.idChangedScheduling !== 0) {
            console.log('Atualização');
            axios.put('http://127.0.0.1:5000/api/Schedulings/' + this.state.idChangedScheduling, {scheduling1 : this.state.scheduling} )

            .then(response => {
                if (response.status === 204) {
                    console.log('O Agendamento ' + this.state.idChangedScheduling + ' foi alterada para ' + this.state.scheduling);
                }
            })

            .then(this.searchScheduling)
        }

        else {
            console.log('Cadastro');
            fetch('http://127.0.0.1:5000/api/Schedulings', {
                method: 'POST',
                body: JSON.stringify({ scheduling : this.state.scheduling}),
                headers:{ "Content-Type" :"application/json"}
            })

            .then(console.log("Especialidade Enviada!"))

            .catch(erro => console.log(erro))

            .then(this.buscarEspecialidades)
             }
    }

    buscarEspecialidadesID = (aespecialidade) => {
        this.setState({
            idEspecialidadeAlterada : aespecialidade.idEspecialidade,
            especialidade : aespecialidade.especialidade1},
            () => {
                console.log('A especialidade ' + aespecialidade.idEspecialidade + 
                ' foi selecionada, sendo no state na alteração a ' + this.state.idEspecialidadeAlterada + 
                ' e sua nomenclatura é: ' + this.state.especialidade)
            })
    }

    render(){
        return(
            <div>
                <main>
                    <section>
                        <h2>Lista de Agendamentos</h2>
                        <table>
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Paciente</th>
                                    <th>Médico</th>
                                    <th>Data</th>
                                    <th>Situação</th>
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.schedulingList.map( (thScheduling) => {
                                        return(
                                            <tr key={thScheduling.idScheduling}>
                                                <td>{thScheduling.idScheduling}</td>
                                                <td>{thScheduling.idPatientNavigation.patientName}</td>
                                                <td>{thScheduling.idMedicNavigation.medicName}</td>
                                                <td>{thScheduling.idMedicNavigation.medicLastname}</td>
                                                <td>{thScheduling.schedulingDateHour}</td>
                                                <td>{thScheduling.idSituationNavigation.situationDescription}</td>

                                                <td><button onClick={() => this.buscarEspecialidadesID(thScheduling)}>Editar</button></td>
                                            </tr>
                                        )
                                    })
                                }
                            </tbody>
                        </table>
                    </section>
                    <section>
                                <h2>Cadastro de Especialidade</h2>
                                <form onSubmit={this.cadastrarEspecialidade}>
                                    <div>
                                        <input type="text"
                                        value={this.state.especialidade}
                                        placeholder="Especialidade"
                                        onChange={this.updateSchedulingField}
                                        />
                                        <button type="submit">Cadastrar</button>
                                    </div>
                                </form>
                    </section>
                </main>
            </div>
        )
    };
}