import { createBrowserRouter, Outlet, RouterProvider } from 'react-router-dom';
import './App.css';
import {Home} from './content/Home/Home';
import {LeaderBoard} from './content/LeaderBoard/LeaderBoard';
import {Login} from './content/Login/Login';
import {Register} from './content/Register/Register';

function Pagina() {

  return (
    <>
      <Outlet/>
    </>
  )
}
const router = createBrowserRouter([
  {
    path: '/',
    element: <Pagina/>,
    errorElement: '',
    children: [
      {
        index: true,
        element: <Home/>
      },
      {
        path: 'home',
        element: <Home/>
      },
      {
        path: 'clasificaciones',
        element: <LeaderBoard/>
      },
      {
        path: 'iniciar-sesion',
        element: <Login/>
      },
      {
        path: 'crear-cuenta',
        element: <Register/>
      }
    ]
  }
]);

const App: React.FC = () => {
  return <RouterProvider router = {router} />
}

export default App;
