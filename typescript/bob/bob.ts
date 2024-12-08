
export function hey(message: string): string {
    const isQuestion = message.trim().slice(-1) === "?";
    const isYelling= /[A-Z]/.test(message) && message.toUpperCase() === message;
    const isSilence = message.trim().length === 0;
    
    if (isQuestion && isYelling) return "Calm down, I know what I'm doing!"
    else if (isYelling) return "Whoa, chill out!"
    else if (isQuestion) return "Sure."
    else if (isSilence) return "Fine. Be that way!"
    return "Whatever.";
}
