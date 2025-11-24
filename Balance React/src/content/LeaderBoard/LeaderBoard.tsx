import './LeaderBoard.css';
import {Header} from '../../components/Header/Header';
import {Footer} from '../../components/Footer/Footer';
import { useState, useEffect } from 'react';

interface ScoreBoardProp {
    name: string,
    bestScore: number,
    lastScore: number,
    gamesPlayed: number
}

export function LeaderBoard(){

    const [usuarios, setUsuarios] = useState<ScoreBoardProp[]>([]);

    useEffect(() => {
        
        const cargandoScore = async () => {
            const res = await fetch("http://localhost:3000/api/score");
            const data = await res.json();
            setUsuarios(data);
        }
        cargandoScore();
    }, []);

    return(
        <>

            <Header/>

            <section className="fondoLeaderBoard">
                <div className="contenedorLeaderBoard">

                    <h1>Tabla de clasificaciones</h1>

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

                        {usuarios?.map((u, index) => (
                            <tr key={index}>
                                <td>{index + 1}</td>
                                <td>{u.name}</td>
                                <td>{u.bestScore}</td>
                                <td>{u.lastScore}</td>
                                <td>{u.gamesPlayed}</td>
                            </tr>
                        ))}
                    </table>
                </div>
            </section>

            <Footer/>

        </>
    );
}