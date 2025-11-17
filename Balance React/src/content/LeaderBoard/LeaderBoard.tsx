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
                                Posición:
                            </td>
                            
                            <td>
                                Nombre de usuario:
                            </td>

                            <td>
                                Mejor puntuacion:
                            </td>

                            <td>
                                Ultima puntuación:
                            </td>

                            <td>
                                Partidas jugadas:
                            </td>
                        </tr>
                    </table>
                </div>
            </section>

            <Footer/>

        </>
    );
}