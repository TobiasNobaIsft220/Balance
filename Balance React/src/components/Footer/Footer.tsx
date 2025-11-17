import './Footer.css'

export function Footer(){
    return(
        <>
            <footer className="footer">
                <div className="footerCreadores">
                    <table className='tablaCreadores'>
                        <tr>
                            <th>Creadores:</th>
                        </tr>
                        <tr>
                            <td>
                                <a href="">Tobbie</a>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <a href="">Chat GPT</a>
                            </td>
                        </tr>
                        
                    </table>
                </div>
            </footer>
        </>
    );
}