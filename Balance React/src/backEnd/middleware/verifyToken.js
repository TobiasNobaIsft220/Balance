import jwt from "jsonwebtoken";

import dotenv from "dotenv";

dotenv.config();

export function verifyToken(req, res, next){
    
    const authHeader = req.headers.authorization;

    if(!authHeader){
        return res.status(401).json({message: "token faltante"});
    }

    const token = authHeader.split(" ")[1];

    jwt.verify(token, process.env.JWT_SECRET, (err, decoded) =>{
        if(err){
            return res.status(401).json({message: "token invalido"});
        }
        req.usuario = decoded;
        next();
    });
}