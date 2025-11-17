import './Register.css';
import {Header} from '../../components/Header/Header';
import {Footer} from '../../components/Footer/Footer';

export function Register(){
    return(
        <>

            <Header/>

            <section className="fondoRegister">
                <div className="contenedorRegister">

                    <div className="contenedorRegisterSuperior">
                        <img className="icon" src="../../../img/Icon-Balance.png" alt="Icon-Balance"/>

                        <h1>Crear cuenta</h1>
                    </div>

                    <div className="contenedorRegisterInferior">
                        <form action="">

                            <label>Nombre de usuario:</label>
                            <br/>

                            <input className='inputRegister' type="text"/>
                            <br/>
                            <br/>

                            <label>Email:</label>
                            <br/>

                            <input className='inputRegister' type="text"/>
                            <br/>
                            <br/>

                            <label>Contraseña:</label>
                            <br/>

                            <input className='inputRegister' type="text" name="" id=""/>
                            <br/>
                            <br/>

                            <label>Repetir contraseña:</label>
                            <br/>

                            <input className='inputRegister' type="text" name="" id=""/>
                            <br/>
                            <br/>

                            <button className="botonRegister">Crear cuenta</button>
                        </form>
                    </div>
                </div>
            </section>

            <Footer/>
            
        </>
    );
}