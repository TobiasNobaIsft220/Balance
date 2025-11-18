import mongoose from "mongoose";

const userSchema = new mongoose.Schema({
    id: {type: Number},
    nombreDeUsuario: {type: String},
    email: {type: String},
    contraseña: {type: String},
    mejorPuntaje: {type: Number},
    ultimoPuntaje: {type: Number},
    partidasJugadas: {type: Number}
});

export default mongoose.model("User", userSchema);