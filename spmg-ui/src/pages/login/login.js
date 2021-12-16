import axios from 'axios';
import { Component } from 'react';
import { parseJwt } from '../../services/auth';

import '../../assets/css/login.css';

export default class Login extends Component {
    constructor(props){
        super(props);
        this.state = {
            email : '',
            passwd : '',
            errorMessage : '',
            isLoading : false
        };
    };

    doLogin = (event) => {
        event.preventDefault();

        this.setState({ errorMessage  : '', isLoading : true})

        axios.post('http://192.168.5.171:5000/api/Login', {email : this.state.email, passwd: this.state.passwd})

        .then(response => {
            if (response.status === 200) {

                localStorage.setItem('user-token', response.data.token)

                console.log('logado com sucesso! Token armazenado no armazenamento local!');

                this.setState({isLoading : false})

                if (parseJwt().role === '1') {
                    this.props.history.push('/dashadmin')
                }

                else {
                    this.props.history.push('/scheduling')
                }

            }
        })
        .catch((erro) => {
            console.log('Houve uma falha. Erro:' + erro);
            this.setState({ errorMessage : 'Email e/ou senha inválidos!!', isLoading: false})
        })
    }

    updateStateField = (field) => {
        this.setState({ [field.target.name] : field.target.value})
    }

    render(){
        return(
            <div>
                <main className="main">
                    <div className="login">
                        <div className="imageLogin">
                            <div className="imageLoginColor"></div>
                        </div>
                        <div className="logoLogin">
                        </div>
                        {/* <div className="loginLogin"> */}
                            <section className="loginLogin">
                                <form onSubmit={this.doLogin}>
                                    {/* <div className="email"> */}
                                    <input
                                    className="email"
                                        type="email"
                                        name="email"
                                        value={this.state.email}
                                        onChange={this.updateStateField}
                                        placeholder="Email" />
                                        {/* </div> */}
                                        {/* <div className="passwd"> */}
                                    <input
                                    className="passwd"
                                        type="password"
                                        name="passwd"
                                        value={this.state.passwd}
                                        onChange={this.updateStateField}
                                        placeholder="Senha" />
                                        {/* </div> */}
                                    {this.state.isLoading === true && <button className="loginButtonLoading" disabled={this.state.isLoading === true}>Carregando...</button>}
                                    {this.state.isLoading === false &&
                                        <button
                                        className="loginButton"
                                            type="submit"
                                            disabled={this.state.email === '' ? 'none' : ''
                                                || this.state.passwd === '' ? 'none' : ''}>Logar</button>}
                                    <p style={{ color: '#ff2400' }}>{this.state.errorMessage}</p>
                                </form>
                            </section>
                        {/* </div> */}
                    </div>
                </main>
            </div>
        )
    }
};