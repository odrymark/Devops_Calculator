import { useState } from "react";
import { Api } from "./Api.ts";

type Operator = "+" | "-" | "*" | "/";

const api = new Api();

export function useCalculatorCrud() {
    const [result, setResult] = useState<string | null>(null);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState<string | null>(null);

    const reset = () => { setResult(null); setError(null); };

    const calculate = async (a: number, operator: Operator, b: number) => {
        setLoading(true); reset();
        try {
            const opMap: Record<Operator, () => Promise<any>> = {
                "+": () => api.api.calculatorAdd({ a, b }),
                "-": () => api.api.calculatorSubtract({ a, b }),
                "*": () => api.api.calculatorMultiply({ a, b }),
                "/": () => api.api.calculatorDivide({ a, b }),
            };
            const res = await opMap[operator]();
            setResult(String(res.data));
        } catch {
            setError("Calculation failed.");
        } finally {
            setLoading(false);
        }
    };

    const checkIsPrime = async (n: number) => {
        setLoading(true); reset();
        try {
            const res = await api.api.calculatorIsPrime({ a: n });
            setResult(res.data ? `${n} is prime ✓` : `${n} is not prime ✗`);
        } catch {
            setError("Request failed.");
        } finally {
            setLoading(false);
        }
    };

    const computeFactorial = async (n: number) => {
        setLoading(true); reset();
        try {
            const res = await api.api.calculatorFactorial({ a: n });
            setResult(String(res.data));
        } catch {
            setError("Request failed.");
        } finally {
            setLoading(false);
        }
    };

    return { calculate, checkIsPrime, computeFactorial, result, loading, error };
}