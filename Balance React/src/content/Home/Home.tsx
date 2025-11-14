import './Home.css';
import {Header} from '../../components/Header/Header';
import {Footer} from '../../components/Footer/Footer';

export function Home(){
    return(
        <>
            <Header/>

            <section className="fondoGifYDescarga">
                    <div className="contenedorGifYDescarga">

                        <img className="gifJuegoBalance" src="../../../img/BalanceHomePageGifCorto(Convertido).gif" alt="Gif-Juego-Balance" />
                        <img className="logoJuegoBalance" src="../../../img/Logo-Balance.png" alt="Logo-Balance"/>
                        <a href="https://github.com/TobiasNobaIsft220/Balance.git" target="_blank" ><button className="botonDescargar">Descargar</button></a>
                    </div>
            </section>

            <Footer/>
        </>

    );
}