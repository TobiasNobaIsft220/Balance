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
                        <a href="https://drive.google.com/file/d/1WHUK3ndR2kEdA3-LI0pdKRlLKgyElqre/view?usp=sharing" target="_blank" ><button className="botonDescargar">Descargar</button></a>
                    </div>
            </section>

            <Footer/>
        </>

    );
}