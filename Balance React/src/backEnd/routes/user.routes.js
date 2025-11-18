import express from "express";
import { registrarUsuario, loginusuario, obtenerUsuarios } from "../controllers/user.controller";

const router = express.Router();

router.post("/registrar", registrarUsuario);

router.post();

router.get();

export default router;