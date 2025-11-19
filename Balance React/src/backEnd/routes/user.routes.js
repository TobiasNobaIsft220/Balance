import express from "express";
import { registerUser, loginUsuario, obtenerUsuarios } from "../controllers/user.controller.js";

const router = express.Router();

router.post("/registrar", registerUser);

router.post("/login", loginUsuario);

router.get("/", obtenerUsuarios);

export default router;