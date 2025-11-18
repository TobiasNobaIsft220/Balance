//Importa el modelo del usuario
import User from "/models/User.js";

//Crea la funcion/metodo para registrar usuarios
export const registrarUsuario = async (req, res) => {
    try {

        //Trae la informacion de los inputs del body
        const { nombreDeUsuario, email, contraseña } = req.body;

        // Validaciones básicas
        if (!nombreDeUsuario || !email || !contraseña) {
            return res.status(400).json({ message: "Faltan datos obligatorios" });
        }

        // Ver si ya existe
        const existeEmail = await User.findOne({ email });
        if (existeEmail) {
            return res.status(400).json({ message: "El email ya está registrado" });
        }

        // Generar ID incremental
        const ultimo = await User.findOne().sort({ id: -1 });
        const nuevoId = ultimo ? ultimo.id + 1 : 1;

        const nuevoUsuario = new User({
            id: nuevoId,
            nombreDeUsuario,
            email,
            contraseña,
            mejorPuntaje: 0,
            ultimoPuntaje: 0,
            partidasJugadas: 0
        });

        await nuevoUsuario.save();

        res.status(201).json({ message: "Usuario creado exitosamente", usuario: nuevoUsuario });

    } catch (error) {
        res.status(500).json({ message: "Error del servidor", error });
    }
};

//Crea la funcion/metodo para registrar usuarios
export const loginusuario = async (req, res) => {
    try{
        const {email, contraseña} = req.body;

        const usuario = await User.findOne({email});

        if(!usuario){
            return res.status(404).json({message: "Usuario no encontrado"});
        }

        if(usuario.contraseña !== contraseña){
            return res.status(400).json({message: "Contraseña incorrecta"});
        }

        res.status(200).json({message: "Login exitoso", usuario});
    }catch (error){
        res.status(500).json({message: "Error en el servidor", error});
    }
};

//Crea la funcion/metodo para mostrar los usuarios
export const obtenerUsuarios = async (req, res) =>{
    try{
        const usuario = await User.find();
        res.status(200).json(usuarios);
        
    }catch(error){
        res.status(500).json({message: "Error del servidor", error})
    }
};

