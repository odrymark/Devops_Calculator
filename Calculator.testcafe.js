import { Selector } from 'testcafe';

const tabs        = Selector('.tab');
const numInputs   = Selector('.num-input');
const opSelect    = Selector('.op-select');
const submitBtn   = Selector('.submit-btn');
const result      = Selector('.result');
const errorResult = Selector('.result-error');

fixture('Calculator')
    .page(BASE_URL);

test('Add two numbers', async t => {
    await t
        .click(tabs.withText('Calculate'))
        .typeText(numInputs.nth(0), '10')
        .click(opSelect)
        .click(Selector('option').withText('+'))
        .typeText(numInputs.nth(1), '5')
        .click(submitBtn)
        .expect(result.innerText).eql('15');
});

test('Subtract two numbers', async t => {
    await t
        .click(tabs.withText('Calculate'))
        .typeText(numInputs.nth(0), '10')
        .click(opSelect)
        .click(Selector('option').withText('−'))
        .typeText(numInputs.nth(1), '5')
        .click(submitBtn)
        .expect(result.innerText).eql('5');
});

test('Multiply two numbers', async t => {
    await t
        .click(tabs.withText('Calculate'))
        .typeText(numInputs.nth(0), '10')
        .click(opSelect)
        .click(Selector('option').withText('×'))
        .typeText(numInputs.nth(1), '5')
        .click(submitBtn)
        .expect(result.innerText).eql('50');
});

test('Divide two numbers', async t => {
    await t
        .click(tabs.withText('Calculate'))
        .typeText(numInputs.nth(0), '10')
        .click(opSelect)
        .click(Selector('option').withText('÷'))
        .typeText(numInputs.nth(1), '5')
        .click(submitBtn)
        .expect(result.innerText).eql('2');
});

test('Divide by zero shows error', async t => {
    await t
        .click(tabs.withText('Calculate'))
        .typeText(numInputs.nth(0), '10')
        .click(opSelect)
        .click(Selector('option').withText('÷'))
        .typeText(numInputs.nth(1), '0')
        .click(submitBtn)
        .expect(errorResult.exists).ok();
});

test('Check if 7 is prime', async t => {
    await t
        .click(tabs.withText('Is Prime?'))
        .typeText(numInputs.nth(0), '7')
        .click(submitBtn)
        .expect(result.innerText).eql('true');
});

test('Check if 4 is not prime', async t => {
    await t
        .click(tabs.withText('Is Prime?'))
        .typeText(numInputs.nth(0), '4')
        .click(submitBtn)
        .expect(result.innerText).eql('false');
});

test('Compute factorial of 5', async t => {
    await t
        .click(tabs.withText('Factorial'))
        .typeText(numInputs.nth(0), '5')
        .click(submitBtn)
        .expect(result.innerText).eql('120');
});