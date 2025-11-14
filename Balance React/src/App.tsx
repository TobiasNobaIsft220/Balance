import { createBrowserRouter, Outlet, RouterProvider } from 'react-router-dom';
import './App.css';
import {Home} from './content/Home/Home'

function Pagina() {

  return (
    <Outlet/>
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
        path: 'iniciar-sesion',
        /*element: {/*login*/
      }
    ]
  }
]);

const App: React.FC = () => {
  return <RouterProvider router = {router} />
}

export default App;
