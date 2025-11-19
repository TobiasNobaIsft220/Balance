import mongoose from "mongoose";

const userSchema = new mongoose.Schema({
    id: {type: Number},
    name: {type: String},
    email: {type: String},
    password: {type: String},
    bestScore: {type: Number},
    lastScore: {type: Number},
    gamesPlayed: {type: Number}
}, {collection: "Users"});

export default mongoose.model("User", userSchema);