Feature: EEQ - Entity equality

    Scenario: [UNT-EEQ001][Success]: Equal entities
        Given I have an 'Entity' with '{BB3D1E10-E112-4DD0-8B5C-115DEF4DA274}' id and 'TestValue1' value
        And I have an 'Entity' with '{BB3D1E10-E112-4DD0-8B5C-115DEF4DA274}' id and 'TestValue2' value
        When I compare two entities
        Then Two entities should be equal

    Scenario Outline: [UNT-EEQ002][Failure]: Unequal entities
        Given I have an 'Entity' with '{BB3D1E10-E112-4DD0-8B5C-115DEF4DA274}' id and 'TestValue1' value
        When I compare the 'Entity' to <entity> with <id> and <value> value
        Then Two entities should be unequal
        Examples:
            | entity | id                                     | value      |
            | null   |                                        |            |
            | object |                                        |            |
            | Entity | {60D854A9-D672-41D6-A869-265FBA45C387} | TestValue2 |
