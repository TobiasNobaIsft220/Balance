import './header.css';

export function Header(){
    return(
        <>
            <header>
                <div className='header'>
                    
                    <nav className="nav">

                        <a href="../Home/Home.html"><img className='icon' src='../../../img/Icon-Balance.png' alt="Icon-Balance" /></a>

                        <a href="../Home/Home.html"><button className="botonNav">Home</button></a>
                        <a href="./Register.html"><button className="botonNav">Clasificaciones</button></a>

                        <a  href="../Login/Login.html"><button className="botonNav">Iniciar sesion</button></a>
                        <a  href="./Register.html"><button className="botonNav">Registrarse</button></a>

                    </nav>

                </div>
            </header>
        </>
    );
}