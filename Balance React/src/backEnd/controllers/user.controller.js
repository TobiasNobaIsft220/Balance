//Importa el modelo del usuario
import User from "../models/User.js";

import jwt from "jsonwebtoken";

import dotenv from "dotenv";

dotenv.config();

//Crea la funcion/metodo para mostrar los usuarios
export const showUsers = async (req, res) =>{
    try{
        const usuarios = await User.find();
        res.json(usuarios);
        
    }catch(error){
        res.status(500).json({message: "Error del servidor", error})
    }
};

//Crea la funcion/metodo para registrar usuarios
export const registerUser = async (req, res) => {
    try {

        //Trae la informacion de los inputs del body
        const { name, email, password, confirmPassword } = req.body;

        // Validaciones básicas
        if (!name || !email || !password || !confirmPassword) {
            return res.status(400).json({ message: "Faltan datos obligatorios" });
        }

        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

        if (!emailRegex.test(email)) {
            return res.status(400).json({ message: "El email no es válido" });
        }

        // Validar contraseñas iguales
        if (password !== confirmPassword) {
            return res.status(400).json({ message: "Las contraseñas no coinciden" });
        }

        // Ver si ya existe
        const existeEmail = await User.findOne({ email });
        if (existeEmail) {
            return res.status(400).json({ message: "Ya existe una cuenta creada con ese Email" });
        }

        // Generar ID incremental
        const ultimo = await User.findOne().sort({ id: -1 });
        const nuevoId = ultimo ? ultimo.id + 1 : 1;

        const nuevoUsuario = new User({
            id: nuevoId,
            name,
            email,
            password,
            bestScore: 0,
            lastScore: 0,
            gamesPlayed: 0
        });

        await nuevoUsuario.save();

        const token = jwt.sign(
            {id: nuevoUsuario.id},
            process.env.JWT_SECRET,
            {expiresIn: "7d"}
        );

        res.status(201).json({
            message: "Usuario creado exitosamente",
            token,
            usuario: {
                id: nuevoUsuario.id,
                nombreDeUsuario: nuevoUsuario.name,
                email: nuevoUsuario.email
            }
        });

    } catch (error) {
        res.status(500).json({ message: "Error del servidor", error });
    }
};

//Crea la funcion/metodo para registrar usuarios
export const loginUser = async (req, res) => {
    try{
        const {email, password} = req.body;

        const usuario = await User.findOne({email});

        if(!usuario){
            return res.status(404).json({message: "Usuario no encontrado"});
        }

        if(usuario.password !== password){
            return res.status(400).json({message: "Contraseña incorrecta"});
        }

        const token = jwt.sign(
            { id: usuario.id },
            process.env.JWT_SECRET,
            { expiresIn: "7d" }
        );

        res.json({
            message: "Sesión iniciada",
            token,
            usuario: {
                id: usuario.id,
                nombreDeUsuario: usuario.name,
                email: usuario.email
            }
        });

    }catch (error){
        res.status(500).json({message: "Error en el servidor", error});
    }
};

export const leaderBoard = async (req, res) =>{
    try{
        const ranking = await User.find()
        .sort({bestScore: -1})
        .select("name bestScore lastScore gamesPlayed");

        res.json(ranking);
    }catch (error){
        res.status(500).json({message: "Error al obtener el leaderboard"})
    }
}

export const updateScore = async (req, res) => {
    try {
        const { puntaje } = req.body;

        const usuario = await User.findOne({ id: req.usuario.id });

        if (!usuario) {
            return res.status(404).json({ message: "Usuario no encontrado" });
        }

        usuario.lastScore = puntaje;

        if (puntaje > usuario.bestScore) {
            usuario.bestScore = puntaje;
        }

        await usuario.save();

        res.json({
            message: "Puntaje actualizado",
            mejorPuntaje: usuario.bestScore,
            ultimoPuntaje: usuario.lastScore
        });
        
    } catch (error) {
        res.status(500).json({ message: "Error al actualizar puntaje" });
    }
};

