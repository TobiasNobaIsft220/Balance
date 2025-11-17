import './Login.css';
import {Header} from '../../components/Header/Header';
import {Footer} from '../../components/Footer/Footer';

export function Login(){
    return(
        <>
            <Header/>

            <section className="fondoLogin">
                <div className="contenedorLogin">

                    <div className="contenedorLoginSuperior">
                        <img className="icon" src="../../../img/Icon-Balance.png" alt="Icon-Balance"/>

                        <h1>Iniciar Sesión</h1>
                    </div>

                    <div className="contenedorLoginInferior">
                        <form action="">

                            <label>Email:</label>
                            <br/>

                            <input className='inputLogin' type="text"/>
                            <br/>
                            <br/>

                            <label>Contraseña:</label>
                            <br/>

                            <input className='inputLogin' type="text" name="" id=""/>
                            <br/>
                            <a className='aLogin' href="crear-cuenta">¿Aun no tienes una cuenta?</a>
                            <br/>
                            <br/>

                            <button className="botonLogin">Iniciar sesión</button>
                        </form>
                    </div>

                </div>
            </section>

            <Footer/>
        </>
    );
}