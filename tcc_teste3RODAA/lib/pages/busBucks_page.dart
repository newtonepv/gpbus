import 'package:flutter/material.dart';

class BusBucks extends StatefulWidget {
  const BusBucks({Key? key}) : super(key: key);

  @override
  _BusBucksPageState createState() => _BusBucksPageState();
}

class _BusBucksPageState extends State<BusBucks> {
  int _busBucksCount = 0;

  void _incrementBusBucksCount(int amount) {
    setState(() {
      _busBucksCount += amount;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: const Color(0xFFFFC966),
        title: const Text('BusBucks'),
        actions: [
          Container(
            margin: const EdgeInsets.only(right: 16),
            child: Row(
              children: [
                const Icon(Icons.monetization_on),
                const SizedBox(width: 6),
                Text('$_busBucksCount'),
              ],
            ),
          ),
        ],
      ),
      body: Container(
        color: const Color(0xFFffebbe),
        child: ListView(
          children: [
            const SizedBox(height: 22),
            const Text(
              'COMPRAR BUSBUCKS',
              style: TextStyle(
                fontSize: 18,
                fontWeight: FontWeight.bold,
                color: Color.fromRGBO(0, 0, 0, 1.0),
              ),
              textAlign: TextAlign.center,
            ),
            const SizedBox(height: 18),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 16),
              child: Text(
                'Ao comprar BusBucks, você desbloqueia uma série de benefícios exclusivos. Além de aproveitar uma forma prática de pagamento, você terá acesso a recursos premium no aplicativo GPbuS.',
                style: TextStyle(
                  fontSize: 16,
                  color: Colors.black,
                ),
                textAlign: TextAlign.center,
              ),
            ),
            const SizedBox(height: 18),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 16),
              child: Column(
                children: [
                  _buildBusBucksOption(
                    context,
                    '20 BB',
                    'R\$ 5,00',
                    20,
                  ),
                  const SizedBox(height: 16),
                  _buildBusBucksOption(
                    context,
                    '50 BB',
                    'R\$ 10,00',
                    50,
                  ),
                  const SizedBox(height: 16),
                  _buildBusBucksOption(
                    context,
                    '90 BB',
                    'R\$ 15,00',
                    90,
                  ),
                  const SizedBox(height: 16),
                  _buildBusBucksOption(
                    context,
                    '170 BB',
                    'R\$ 20,00',
                    170,
                  ),
                ],
              ),
            ),
          ],
        ),
        
      ),
    );
  }

  Widget _buildBusBucksOption(
    BuildContext context,
    String amount,
    String price,
    int busBucksCount,
  ) {
    return Container(
      margin: const EdgeInsets.only(top: 0),
      decoration: BoxDecoration(
        border: Border.all(
          color: Colors.grey,
          width: 1.0,
        ),
        borderRadius: BorderRadius.circular(8),
      ),
      child: ListTile(
        title: Text(
          amount,
          style: const TextStyle(
            fontWeight: FontWeight.bold,
          ),
        ),
        subtitle: Text(price),
        trailing: ElevatedButton(
          onPressed: () {
            _incrementBusBucksCount(busBucksCount);
          },
          style: ElevatedButton.styleFrom(
            backgroundColor: const Color(0xFFffc966),
          ),
          child: const Text('Comprar'),
        ),
      ),
    );
  }
}
