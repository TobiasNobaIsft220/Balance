import express from "express";
import { showUsers, registerUser, loginUser, leaderBoard, showPerfil, updateScore, updateGamesPlayed} from "../controllers/user.controller.js";
import { verifyToken } from "../middleware/verifyToken.js";


const router = express.Router();

router.get("/users", showUsers);

router.post("/register", registerUser);

router.post("/login", loginUser);

router.get("/score", leaderBoard);

router.get("/perfil", verifyToken, showPerfil);

router.post("/updateScore", verifyToken, updateScore);

router.post("/updateGamesPlayed", verifyToken, updateGamesPlayed);

export default router;