import './LeaderBoard.css';
import {Header} from '../../components/Header/Header';
import {Footer} from '../../components/Footer/Footer';

export function LeaderBoard(){
    return(
        <>

            <Header/>

            <section className="fondoLeaderBoard">
                <div className="contenedorLeaderBoard">
                    <table className='tablaLeaderBoard'>
                        <tr>
                            <th>
                                Posición:
                            </th>
                            
                            <th>
                                Nombre de usuario:
                            </th>

                            <th>
                                Mejor puntuacion:
                            </th>

                            <th>
                                Ultima puntuación:
                            </th>

                            <th>
                                Partidas jugadas:
                            </th>
                        </tr>

                        <tr>
                            <td>
                                1
                            </td>
                            
                            <td>
                                Tobbie
                            </td>

                            <td>
                                1238
                            </td>

                            <td>
                                103
                            </td>

                            <td>
                                21
                            </td>
                        </tr>
                    </table>
                </div>
            </section>

            <Footer/>

        </>
    );
}