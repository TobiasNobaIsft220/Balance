import express from "express";
import { registerUser, loginUser, obtenerUsuarios } from "../controllers/user.controller.js";
import { verfyToken } from "../middleware/verifyToken.js";
import User from "../models/User.js";


const router = express.Router();

router.post("/registrar", registerUser);

router.post("/login", loginUser);

router.get("/perfil", verfyToken, async (req, res) =>{
    try{
        const usuario = await User.findOne({id: req.usuario.id});
        res.json({usuario});
    }catch(error){
        res.status(500).json({message: "error al obtener el perfil"});
    }
})

router.get("/", obtenerUsuarios);

export default router;