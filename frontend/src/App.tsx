import { useState } from "react";
import { useCalculatorCrud } from "./useCalculatorCrud";
import "./Calculator.css";

type Operator = "+" | "-" | "*" | "/";
type Mode = "calculate" | "isprime" | "factorial";

const OP_LABELS: Record<Operator, string> = { "+": "+", "-": "−", "*": "×", "/": "÷" };

export default function Calculator() {
    const [mode, setMode] = useState<Mode>("calculate");
    const [a, setA] = useState("");
    const [b, setB] = useState("");
    const [operator, setOperator] = useState<Operator>("+");
    const [singleInput, setSingleInput] = useState("");

    const { calculate, checkIsPrime, computeFactorial, result, loading, error } = useCalculatorCrud();

    const handleNumberInput = (setter: (v: string) => void) => (e: React.ChangeEvent<HTMLInputElement>) => {
        const val = e.target.value;
        if (val === "" || val === "-" || /^-?\d*\.?\d*$/.test(val)) setter(val);
    };

    const handleSubmit = () => {
        if (mode === "calculate") {
            const numA = parseFloat(a);
            const numB = parseFloat(b);
            if (!isNaN(numA) && !isNaN(numB)) calculate(numA, operator, numB);
        } else if (mode === "isprime") {
            const n = parseInt(singleInput);
            if (!isNaN(n)) checkIsPrime(n);
        } else {
            const n = parseInt(singleInput);
            if (!isNaN(n)) computeFactorial(n);
        }
    };

    const switchMode = (m: Mode) => {
        setMode(m);
        setA(""); setB(""); setSingleInput("");
    };

    return (
        <div className="calc-wrap">
            <div className="calc">
                <div className="tabs">
                    {(["calculate", "isprime", "factorial"] as Mode[]).map(m => (
                        <button
                            key={m}
                            className={`tab ${mode === m ? "tab-active" : ""}`}
                            onClick={() => switchMode(m)}
                        >
                            {m === "calculate" ? "Calculate" : m === "isprime" ? "Is Prime?" : "Factorial"}
                        </button>
                    ))}
                </div>

                {mode === "calculate" ? (
                    <div className="inputs">
                        <input
                            className="num-input"
                            type="text"
                            inputMode="decimal"
                            placeholder="0"
                            value={a}
                            onChange={handleNumberInput(setA)}
                        />
                        <select
                            className="op-select"
                            value={operator}
                            onChange={e => setOperator(e.target.value as Operator)}
                        >
                            {(Object.entries(OP_LABELS) as [Operator, string][]).map(([val, label]) => (
                                <option key={val} value={val}>{label}</option>
                            ))}
                        </select>
                        <input
                            className="num-input"
                            type="text"
                            inputMode="decimal"
                            placeholder="0"
                            value={b}
                            onChange={handleNumberInput(setB)}
                        />
                    </div>
                ) : (
                    <input
                        className="num-input num-input-full"
                        type="text"
                        inputMode="numeric"
                        placeholder="Enter a number"
                        value={singleInput}
                        onChange={e => { if (/^\d*$/.test(e.target.value)) setSingleInput(e.target.value); }}
                    />
                )}

                <button className="submit-btn" onClick={handleSubmit} disabled={loading}>
                    {loading ? "..." : mode === "calculate" ? "Calculate" : mode === "isprime" ? "Check" : "Compute"}
                </button>

                {result !== null && <div className="result">{result}</div>}
                {error !== null && <div className="result result-error">{error}</div>}
            </div>
        </div>
    );
}