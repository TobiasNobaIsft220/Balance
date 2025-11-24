import express from "express";
import { showUsers, registerUser, loginUser, leaderBoard } from "../controllers/user.controller.js";
import { verifyToken } from "../middleware/verifyToken.js";
import User from "../models/User.js";


const router = express.Router();

router.get("/users", showUsers);

router.post("/register", registerUser);

router.post("/login", loginUser);

router.get("/score", leaderBoard);

router.get("/perfil", verifyToken, async (req, res) =>{
    try{
        const usuario = await User.findOne({id: req.usuario.id});
        res.json({usuario});
    }catch(error){
        res.status(500).json({message: "error al obtener el perfil"});
    }
});

export default router;