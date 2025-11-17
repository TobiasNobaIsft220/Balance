import './header.css';

export function Header(){
    return(
        <>
            <header>
                <div className='header'>
                    
                    <nav className="nav">

                        <a href="home"><img className='icon' src='../../../img/Icon-Balance.png' alt="Icon-Balance" /></a>

                        <a href="home"><button className="botonNav">Home</button></a>
                        <a href="clasificaciones"><button className="botonNav">Clasificaciones</button></a>

                        <a  href="iniciar-sesion"><button className="botonNav">Iniciar sesión</button></a>
                        <a  href="crear-cuenta"><button className="botonNav">Crear cuenta</button></a>

                    </nav>

                </div>
            </header>
        </>
    );
}